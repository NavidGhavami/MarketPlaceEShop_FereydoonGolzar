using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.DTOs.ProductOrder;
using MarketPlace.DataLayer.DTOs.Seller;
using MarketPlace.DataLayer.Entities.ProductDiscount;
using MarketPlace.DataLayer.Entities.ProductOrder;
using MarketPlace.DataLayer.Entities.Store;
using MarketPlace.DataLayer.Entities.Wallet;
using MarketPlace.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class OrderService : IOrderService
    {
        #region Constructor

        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        private readonly ISellerWalletService _sellerWalletService;
        private readonly IGenericRepository<ProductDiscount> _productDiscountRepository;
        private readonly IGenericRepository<ProductDiscountUse> _productDiscountUseRepository;

        public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<OrderDetail> orderDetailRepository,
            ISellerWalletService sellerWalletService, IGenericRepository<ProductDiscount> productDiscountRepository,
            IGenericRepository<ProductDiscountUse> productDiscountUseRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _sellerWalletService = sellerWalletService;
            _productDiscountRepository = productDiscountRepository;
            _productDiscountUseRepository = productDiscountUseRepository;
        }

        #endregion


        #region Order

        public async Task<long> AddOrderForUser(long userId)
        {
            var order = new Order { UserId = userId , OrderAcceptanceState = OrderAcceptanceState.UnderProgress};

            await _orderRepository.AddEntity(order);

            await _orderRepository.SaveChanges();

            return order.Id;

        }

        public async Task<Order> GetUserLatestOpenOrder(long userId)
        {
            if (!await _orderRepository.GetQuery().AnyAsync(x => x.UserId == userId && !x.IsPaid))
            {
                await AddOrderForUser(userId);
            }
            var userOpenOrder = await _orderRepository.GetQuery()
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.ProductColor)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductDiscounts)
                .SingleOrDefaultAsync(x => x.UserId == userId && !x.IsPaid);


            return userOpenOrder;
        }

        public async Task<int> GetTotalOrderPriceForPayment(long userId)
        {
            var userOpenOrder = await GetUserLatestOpenOrder(userId);
            var totalPrice = 0;
            var discount = 0;

            foreach (var detail in userOpenOrder.OrderDetails.Where(x => !x.IsDelete))
            {
                var oneProductPrice = detail.ProductColor != null
                    ? detail.Product.Price + Convert.ToInt32(detail.ProductColor.Price)
                    : detail.Product.Price;

                var productDiscount = await _productDiscountRepository.GetQuery()
                    .Include(x => x.ProductDiscountUse)
                    .OrderByDescending(x => x.CreateDate)
                    .FirstOrDefaultAsync(x =>
                        x.ProductId == detail.ProductId && x.DiscountNumber - x.ProductDiscountUse.Count > 0);

                if (productDiscount != null)
                {
                    discount = (int)Math.Ceiling((oneProductPrice * productDiscount.Percentage) / (decimal)100);
                }


                totalPrice += detail.Count * (oneProductPrice - discount);
                discount = 0;
            }

            return totalPrice;
        }

        public async Task PayOrderProductPriceToSeller(long userId, long refId, string trackingCode)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);

            foreach (var detail in openOrder.OrderDetails)
            {
                var productPrice = detail.Product.Price;
                var productColorPrice = detail.ProductColor != null ? Convert.ToInt32(detail.ProductColor.Price) : 0;
                var discount = 0;
                var totalPrice = (detail.Count * (productPrice + productColorPrice));

                var productDiscount = await _productDiscountRepository.GetQuery()
                    .Include(x => x.ProductDiscountUse)
                    .OrderByDescending(x => x.CreateDate)
                    .FirstOrDefaultAsync(x =>
                        x.ProductId == detail.ProductId && x.DiscountNumber - x.ProductDiscountUse.Count > 0);

                if (productDiscount != null)
                {
                    discount = (int)Math.Ceiling((totalPrice * productDiscount.Percentage) / (decimal)100);

                    var newDiscountUse = new ProductDiscountUse
                    {
                        UserId = userId,
                        ProductDiscountId = productDiscount.Id,
                    };

                    await _productDiscountUseRepository.AddEntity(newDiscountUse);
                }

                var totalPriceWithDiscount = totalPrice - discount;

                var sellerWallet = new SellerWallet
                {
                    SellerId = detail.Product.SellerId,
                    Price = (int)Math.Ceiling(totalPriceWithDiscount - (totalPriceWithDiscount * detail.Product.SiteProfit / (double)100)),
                    TransactionType = TransactionType.Deposit,
                    Description = $"پرداخت مبلغ {totalPriceWithDiscount:#,0 تومان}، جهت فروش محصول {detail.Product.Title}،" +
                                  $" با قیمت کل {totalPrice:#,0 تومان}، با مبلغ تخفیف" +
                                  $" {discount:#,0 تومان}، به تعداد {detail.Count} عدد، با سهم تعیین شده ی {100 - detail.Product.SiteProfit} " +
                                  $"درصد برای فروشنده و {detail.Product.SiteProfit} درصد برای فروشگاه" 
                };

                await _sellerWalletService.AddWallet(sellerWallet);

                detail.ProductPrice = totalPriceWithDiscount;
                detail.ProductColorPrice = productColorPrice;

                _orderDetailRepository.EditEntity(detail);
            }

            openOrder.IsPaid = true;
            openOrder.TrackingCode = trackingCode;
            openOrder.PaymentDate = DateTime.Now;
            openOrder.OrderAcceptanceState = OrderAcceptanceState.PaymentSuccessful;
            openOrder.Description = $"سفارش شما در تاریخ {DateTime.Now.ToShamsi()} با موفقیت ثبت شد.";
            _orderRepository.EditEntity(openOrder);


            await _orderRepository.SaveChanges();
        }

        public async Task<FilterUserOrderDTO> GetUserOrder(FilterUserOrderDTO filter)
        {
            var query = _orderRepository.GetQuery()
               .Include(x => x.OrderDetails)
               .AsQueryable()
               .OrderByDescending(x => x.Id)
               .Where(x=>x.TrackingCode != null);

            #region State

            switch (filter.FilterUserOrderState)
            {
                case FilterUserOrderState.All:
                    query = query.Where(x => !x.IsDelete);
                    break;
                case FilterUserOrderState.PaymentSuccessful:
                    query = query.Where(x => x.OrderAcceptanceState == OrderAcceptanceState.PaymentSuccessful && !x.IsDelete);
                    break;
                case FilterUserOrderState.PaymentCancel:
                    query = query.Where(x => x.OrderAcceptanceState == OrderAcceptanceState.PaymentCancel && !x.IsDelete);
                    break;
                case FilterUserOrderState.UnderProgress:
                    query = query.Where(x => x.OrderAcceptanceState == OrderAcceptanceState.UnderProgress && !x.IsDelete);
                    break;
            }

            #endregion

            #region Filter

            if (filter.UserId != null && filter.UserId != 0)
            {
                query = query.Where(x => x.UserId == filter.UserId);
            }

            if (!string.IsNullOrEmpty(filter.TrackingCode))
            {
                query = query.Where(x => EF.Functions.Like(x.TrackingCode, $"%{filter.TrackingCode}%"));
            }

            #endregion

            #region Paging


            var orderCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, orderCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();


            #endregion

            return filter.SetPaging(pager).SetUserOrders(allEntities);
        }

        public async Task<CancelOrderResult> CancelOrder(CancelOrderDTO cancel, long userId)
        {
            var order = await _orderRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == cancel.Id);

            if (order != null)
            {
                if (!order.IsPaid && order.UserId != userId)
                {
                    return CancelOrderResult.OrderNotFound;
                }

                order.OrderAcceptanceState = OrderAcceptanceState.PaymentCancel;
                order.Description = cancel.Description;
                order.LastUpdateDate = DateTime.Now;

                _orderRepository.EditEntity(order);
                await _orderRepository.SaveChanges();

                return CancelOrderResult.Success;
            }

            return CancelOrderResult.Error;

        }

        public async Task<CancelOrderDTO> GetOrderForCancel(long orderId, long userId)
        {
            var order = await _orderRepository.GetEntityById(orderId);

            if (order == null)
            {
                return null;
            }

            return new CancelOrderDTO
            {
                Id = order.Id,
                Description = order.Description,
                CancelOrderDate = order.LastUpdateDate.ToString("yyyy/MM/dd"),
                SuccessOrderDate = order.CreateDate.ToString("yyyy/MM/dd"),
            };
        }

        #endregion

        #region Order Details

        public async Task AddProductToOpenOrder(long userId, AddProductToOrderDTO order)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);

            var similarOrder = openOrder.OrderDetails.SingleOrDefault(x =>
                x.ProductId == order.ProductId && x.ProductColorId == order.ProductColorId && !x.IsDelete);

            if (similarOrder == null)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = openOrder.Id,
                    ProductId = order.ProductId,
                    ProductColorId = order.ProductColorId,
                    Count = order.Count
                };

                await _orderDetailRepository.AddEntity(orderDetail);
                await _orderDetailRepository.SaveChanges();
            }
            else
            {
                similarOrder.Count += order.Count;
                await _orderDetailRepository.SaveChanges();
            }


        }

        public async Task<UserOpenOrderDTO> GetUserOpenOrderDetail(long userId)
        {
            var userOpenOrder = await GetUserLatestOpenOrder(userId);

            return new UserOpenOrderDTO
            {
                UserId = userId,
                Description = userOpenOrder.Description,
                Details = userOpenOrder.OrderDetails
                    .Where(x => !x.IsDelete)
                    .Select(x => new UserOpenOrderDetailItemDTO
                    {
                        Id = x.Id,
                        Count = x.Count,
                        ColorName = x.ProductColor?.ColorName,
                        ProductColorId = x.ProductColorId,
                        ProductColorPrice = x.ProductColor != null ? Convert.ToInt32(x.ProductColor.Price) : 0,
                        ProductId = x.ProductId,
                        ProductPrice = x.Product.Price,
                        ProductTitle = x.Product.Title,
                        ProductImage = x.Product.Image,
                        DiscountPercentage = x.Product.ProductDiscounts
                        .OrderByDescending(p => p.CreateDate)
                        .FirstOrDefault(p => p.ExpireDate > DateTime.Now)?.Percentage


                    }).ToList()
            };
        }

        public async Task<bool> RemoveOrderDetail(long detailId, long userId)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);
            var orderDetail = openOrder.OrderDetails.SingleOrDefault(x => x.Id == detailId);

            if (orderDetail == null)
            {
                return false;
            }

            _orderDetailRepository.DeleteEntity(orderDetail);
            await _orderDetailRepository.SaveChanges();

            return true;
        }

        public async Task ChangeOrderDetailCount(long detailId, long userId, int count)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);
            var detail = openOrder.OrderDetails.SingleOrDefault(x => x.Id == detailId);

            if (detail != null)
            {
                if (count > 0)
                {
                    detail.Count = count;
                }
                else
                {
                    _orderDetailRepository.DeleteEntity(detail);
                }

                await _orderDetailRepository.SaveChanges();
            }
        }

        public async Task<List<UserOrderDetailItemDTO>> GetUserOrderDetailItem(long orderId, long userId)
        {
            var order = await _orderRepository
                .GetQuery()
                .AsQueryable()
                .Include(x=>x.OrderDetails)
                .ThenInclude(x=>x.Product)
                .ThenInclude(x => x.ProductColors)
                .Include(x=>x.OrderDetails)
                .ThenInclude(x=>x.Product.Seller)
                .FirstOrDefaultAsync(x => x.Id == orderId && x.UserId == userId);

            if (order == null)
            {
                return null;
            }

            var discount = await _productDiscountRepository
                .GetQuery()
                .AsQueryable()
                .Select(x => new {x.ProductId, x.Percentage}).ToListAsync();

            var items = order.OrderDetails.Select(x => new UserOrderDetailItemDTO
            {
                OrderId = x.Id,
                ProductId = x.ProductId,
                ProductTitle = x.Product.Title,
                StoreName = x.Product.Seller.StoreName,
                ColorName = x.ProductColor.ColorName,
                Count = x.Count,
                ProductColorPrice = Convert.ToInt32(x.ProductColor.Price),
                ProductPrice = x.ProductPrice,
                MainProductPrice = x.Product.Price + x.ProductColorPrice,
                ProductColorId = x.ProductColorId,
                ProductImage = x.Product.Image,

            }).ToList();


            foreach (var item in items)
            {
                item.DiscountPercentage = discount
                    .FirstOrDefault(x => x.ProductId == item.ProductId)?.Percentage;

                item.DiscountPrice = item.MainProductPrice - item.ProductPrice;
            }

            return items;

        }

        #endregion




        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_orderRepository != null)
            {
                await _orderRepository.DisposeAsync();
            }

            if (_orderDetailRepository != null)
            {
                await _orderDetailRepository.DisposeAsync();
            }
            if (_productDiscountRepository != null)
            {
                await _productDiscountRepository.DisposeAsync();
            }
            if (_productDiscountUseRepository != null)
            {
                await _productDiscountUseRepository.DisposeAsync();
            }
        }



        #endregion
    }
}
