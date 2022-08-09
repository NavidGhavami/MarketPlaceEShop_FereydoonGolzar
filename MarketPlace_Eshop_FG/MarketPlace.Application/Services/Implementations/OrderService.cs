using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Utilities;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.DTOs.ProductOrder;
using MarketPlace.DataLayer.Entities.ProductDiscount;
using MarketPlace.DataLayer.Entities.ProductOrder;
using MarketPlace.DataLayer.Entities.Shipping;
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
        private readonly ISellerService _sellerService;
        private readonly IGenericRepository<ProductDiscount> _productDiscountRepository;
        private readonly IGenericRepository<ProductDiscountUse> _productDiscountUseRepository;
        private readonly IGenericRepository<UserAddress> _userAddressRepository;
        private readonly IGenericRepository<Shipping> _shippingRepository;

        public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<OrderDetail> orderDetailRepository,
            ISellerWalletService sellerWalletService, IGenericRepository<ProductDiscount> productDiscountRepository,
            IGenericRepository<ProductDiscountUse> productDiscountUseRepository, ISellerService sellerService, IGenericRepository<UserAddress> userAddressRepository,
            IGenericRepository<Shipping> shippingRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _sellerWalletService = sellerWalletService;
            _productDiscountRepository = productDiscountRepository;
            _productDiscountUseRepository = productDiscountUseRepository;
            _sellerService = sellerService;
            _userAddressRepository = userAddressRepository;
            _shippingRepository = shippingRepository;
        }

        #endregion


        #region Order

        public async Task<long> AddOrderForUser(long userId)
        {
            var order = new Order { UserId = userId, OrderAcceptanceState = OrderAcceptanceState.UnderProgress };
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
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Shipping)
                .SingleOrDefaultAsync(x => x.UserId == userId && !x.IsPaid);


            return userOpenOrder;
        }

        public async Task<int> GetTotalOrderPriceForPayment(long userId)
        {
            var userOpenOrder = await GetUserLatestOpenOrder(userId);
            var totalShippingPrice = 0;
            var totalPrice = 0;
            var discount = 0;

            foreach (var detail in userOpenOrder.OrderDetails.Where(x => !x.IsDelete))
            {
                var oneProductPrice = detail.ProductColor != null
                    ? detail.Product.Price + Convert.ToInt32(detail.ProductColor.Price) + detail.Shipping.TotalShippingPrice
                    : detail.Product.Price;

                var productDiscount = await _productDiscountRepository.GetQuery()
                    .Include(x => x.ProductDiscountUse)
                    .OrderByDescending(x => x.CreateDate)
                    .FirstOrDefaultAsync(x =>
                        x.ProductId == detail.ProductId && x.ExpireDate >= DateTime.Now);

                totalShippingPrice += detail.Count * detail.Shipping.TotalShippingPrice;

                if (productDiscount != null)
                {
                    discount = (int)Math.Ceiling(((oneProductPrice - detail.Shipping.TotalShippingPrice) * productDiscount.Percentage) / (decimal)100);
                }


                totalPrice += detail.Count * (oneProductPrice - discount);

                discount = 0;
            }

            if (totalPrice >= 400000)
            {
                totalPrice -= totalShippingPrice;
            }

            return totalPrice;
        }

        public async Task<string> GetOrderBy(long orderId)
        {
            var order = await _orderRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                return null;
            }

            return order.TrackingCode;



        }

        public async Task PayOrderProductPriceToSeller(long userId, long refId, string trackingCode)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);

            foreach (var detail in openOrder.OrderDetails)
            {
                var productPrice = detail.Product.Price;
                var productColorPrice = detail.ProductColor != null ? Convert.ToInt32(detail.ProductColor.Price) : 0;
                var productShippingPrice = detail.Shipping.TotalShippingPrice;
                var discount = 0;
                var totalPrice = detail.Count * (productPrice + productColorPrice);

                var productDiscount = await _productDiscountRepository.GetQuery()
                    .Include(x => x.ProductDiscountUse)
                    .OrderByDescending(x => x.CreateDate)
                    .FirstOrDefaultAsync(x =>
                        x.ProductId == detail.ProductId && x.ExpireDate >= DateTime.Now);

                if (productDiscount != null)
                {
                    discount = (int)Math.Ceiling(totalPrice * productDiscount.Percentage / (decimal)100);

                    var newDiscountUse = new ProductDiscountUse
                    {
                        UserId = userId,
                        ProductDiscountId = productDiscount.Id,
                    };

                    await _productDiscountUseRepository.AddEntity(newDiscountUse);
                }

                var totalPriceWithDiscount = (totalPrice + detail.Count * productShippingPrice) - discount;

                var sellerWallet = new SellerWallet
                {
                    SellerId = detail.Product.SellerId,
                    Price = (int)Math.Ceiling(totalPriceWithDiscount - totalPriceWithDiscount * detail.Product.SiteProfit / (double)100),
                    TransactionType = TransactionType.Deposit,
                    Description = $"سفارش با کد پیگیری {trackingCode}، با کد رهگیری پرداخت {refId}،" +
                                  $" با پرداخت مبلغ {totalPriceWithDiscount:#,0 تومان}، جهت فروش محصول {detail.Product.Title}،" +
                                  $" با قیمت کل {totalPrice:#,0 تومان}، با مبلغ تخفیف" + $" {discount:#,0 تومان}، " +
                                  $" با هزینه پستی {productShippingPrice * detail.Count:#,0 تومان}،" +
                                  $"به تعداد {detail.Count} عدد، با سهم تعیین شده ی {100 - detail.Product.SiteProfit} " +
                                  $"درصد برای فروشنده و {detail.Product.SiteProfit} درصد برای فروشگاه"
                };

                await _sellerWalletService.AddWallet(sellerWallet);

                detail.ProductPrice = totalPriceWithDiscount;
                detail.ProductColorPrice = productColorPrice;
                detail.ShippingPrice = productShippingPrice * detail.Count;

                _orderDetailRepository.EditEntity(detail);
            }

            openOrder.IsPaid = true;
            openOrder.RefId = refId.ToString();
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
               .Where(x => x.TrackingCode != null);

            #region State

            switch (filter.FilterUserOrderState)
            {
                case FilterUserOrderState.All:
                    query = query.Where(x => !x.IsDelete);
                    break;
                case FilterUserOrderState.PaymentSuccessful:
                    query = query.Where(x => x.OrderAcceptanceState == OrderAcceptanceState.PaymentSuccessful && !x.IsDelete);
                    break;
                case FilterUserOrderState.PaymentNotSuccessful:
                    query = query.Where(x => x.OrderAcceptanceState == OrderAcceptanceState.PaymentNotSuccessful && !x.IsPaid && !x.IsDelete);
                    break;
                case FilterUserOrderState.PaymentCancel:
                    query = query.Where(x => x.OrderAcceptanceState == OrderAcceptanceState.PaymentCancel && x.IsPaid && !x.IsDelete);
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
                CancelOrderDate = DateTime.Now.ToFarsi(),
                SuccessOrderDate = order.PaymentDate.ToFarsi()
            };
        }

        public async Task<FilterSellerOrderDTO> GetOrderForSeller(FilterSellerOrderDTO filter)
        {

            var query = _orderDetailRepository
                .GetQuery()
                .AsQueryable()
                .Include(x => x.Order)
                .ThenInclude(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .Where(x => x.Product.SellerId == filter.SellerId && x.Order.IsPaid)
                .Select(x => x.Order)
                .OrderByDescending(x => x.Id);




            #region Paging


            var orderCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, orderCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();


            #endregion

            return filter.SetPaging(pager).SetSellerOrder(allEntities);
        }

        public async Task<AddUserAddressResult> AddUserAddress(UserAddressDTO address, long userId)
        {
            var similarUserAddress = await _userAddressRepository.GetQuery()
                .SingleOrDefaultAsync(x => x.OrderId == address.OrderId);

            if (similarUserAddress == null)
            {
                var addUserAddress = new UserAddress
                {
                    UserId = userId,
                    OrderId = address.OrderId,
                    Name = address.Name,
                    Family = address.Family,
                    State = address.State,
                    City = address.City,
                    Street = address.Street,
                    PostalCode = address.PostalCode,
                    PlaqueNo = address.PlaqueNo,
                    Company = address.Company,
                    Mobile = address.Mobile,
                    Email = address.Email,
                    Description = address.Description,
                    PaymentMethod = "پرداخت آنلاین",
                };

                await _userAddressRepository.AddEntity(addUserAddress);
                await _userAddressRepository.SaveChanges();

                return AddUserAddressResult.Success;
            }
            else
            {
                var userAddressDto = new UserAddressDTO();
                return AddUserAddressResult.Success;
            }

        }

        public async Task<List<UserAddress>> GetAddressToUser(long userId)
        {
            return await _userAddressRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Id)
                .Take(5)
                .ToListAsync();
        }

        public async Task<UserAddressDTO> GetUserAddressForOrder(long orderId, long userId)
        {
            var userAddress = await _userAddressRepository
                .GetQuery()
                .AsQueryable()
                .Include(x => x.Order)
                .Select(x => new UserAddressDTO
                {
                    OrderId = x.OrderId,
                    UserId = x.UserId,
                    Name = x.Name,
                    Family = x.Family,
                    Company = x.Company,
                    State = x.State,
                    City = x.City,
                    Street = x.Street,
                    Mobile = x.Mobile,
                    Email = x.Email,
                    PostalCode = x.PostalCode,
                    PlaqueNo = x.PlaqueNo,
                    PaymentMethod = x.PaymentMethod,
                    Description = x.Description,
                    Order = x.Order
                })
                .SingleOrDefaultAsync(x => x.OrderId == orderId && x.UserId == userId);

            return userAddress;
        }

        public async Task<UserAddressDTO> GetExistUserAddress(long userId)
        {
            var userAddress = await _userAddressRepository
                .GetQuery()
                .AsQueryable()
                .OrderBy(x => x.CreateDate)
                .LastOrDefaultAsync(x => x.UserId == userId);

            if (userAddress == null)
            {
                return null;
            }

            return new UserAddressDTO
            {
                Name = userAddress.Name,
                Family = userAddress.Family,
                Company = userAddress.Company,
                State = userAddress.State,
                City = userAddress.City,
                Street = userAddress.Street,
                PostalCode = userAddress.PostalCode,
                PlaqueNo = userAddress.PlaqueNo,
                Mobile = userAddress.Mobile,
                Email = userAddress.Email,

            };
        }

        public async Task<bool> AddOrderToNoneAuthenticatedUser(long userId)
        {
            var order = await _orderRepository
                .GetQuery()
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.UserId == 0 /*&& x.CreateDate.AddDays(2) >= DateTime.Now*/);


            if (order.UserId == 0)
            {
                order.UserId = userId;
                _orderRepository.EditEntity(order);
                await _orderRepository.SaveChanges();

                return true;
            }


            return false;

        }

        #endregion

        #region Order Details

        public async Task AddProductToOpenOrder(long userId, AddProductToOrderDTO order)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);

            var similarOrder = openOrder.OrderDetails.SingleOrDefault(x =>
                x.ProductId == order.ProductId && x.ProductColorId == order.ProductColorId && x.ShippingId == order.ProductShippingId && !x.IsDelete);

            if (similarOrder == null)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = openOrder.Id,
                    ProductId = order.ProductId,
                    ProductColorId = order.ProductColorId,
                    ShippingId = order.ProductShippingId,
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
                        ProductShippingId = x.ShippingId,
                        ProductShippingPrice = x.Shipping.TotalShippingPrice,
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
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductColors)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product.Seller)
                .FirstOrDefaultAsync(x => x.Id == orderId && x.UserId == userId);

            if (order == null)
            {
                return null;
            }

            var discount = await _productDiscountRepository
                .GetQuery()
                .AsQueryable()
                .Select(x => new { x.ProductId, x.Percentage, x.ExpireDate }).ToListAsync();

            var shipping = await _shippingRepository
                .GetQuery()
                .AsQueryable()
                .Select(x => new { x.ProductId, x.TotalShippingPrice }).ToListAsync();

            var items = order.OrderDetails.Where(x => !x.IsDelete).Select(x => new UserOrderDetailItemDTO
            {
                OrderId = x.Id,
                ProductId = x.ProductId,
                ProductTitle = x.Product.Title,
                StoreName = x.Product.Seller.StoreName,
                ColorName = x.ProductColor.ColorName,
                Count = x.Count,
                ProductColorPrice = Convert.ToInt32(x.ProductColor.Price),
                ProductPrice = x.ProductPrice,
                OriginalProductPrice = x.Product.Price,
                MainProductPrice = (x.Product.Price + x.ProductColorPrice) * x.Count + x.ShippingPrice,
                ProductShippingPrice = x.ShippingPrice,
                ProductColorId = x.ProductColorId,
                ProductImage = x.Product.Image,

            }).ToList();


            foreach (var item in items)
            {
                item.DiscountPercentage = discount
                        .FirstOrDefault(x => x.ProductId == item.ProductId)?.Percentage;

                item.DiscountPrice = item.MainProductPrice - item.ProductPrice;

                item.ProductShippingPrice = Convert.ToInt32(shipping
                    .FirstOrDefault(x => x.ProductId == item.ProductId)?.TotalShippingPrice * item.Count);
            }

            return items;

        }

        public async Task<List<SellerOrderDetailItemDTO>> GetSellerOrderDetailItem(long orderId, long sellerId)
        {

            var orderDetail = _orderDetailRepository
                .GetQuery()
                .AsQueryable()
                .Include(x => x.Order)
                .ThenInclude(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .Where(x => x.OrderId == orderId && x.Order.IsPaid && x.Product.SellerId == sellerId && !x.IsDelete)
                .OrderByDescending(x => x.Id);


            var discount = await _productDiscountRepository
                .GetQuery()
                .AsQueryable()
                .Select(x => new { x.ProductId, x.Percentage, x.ExpireDate }).ToListAsync();

            var shipping = await _shippingRepository
                .GetQuery()
                .AsQueryable()
                .Select(x => new { x.ProductId, x.TotalShippingPrice }).ToListAsync();

            var items = orderDetail.Select(x => new SellerOrderDetailItemDTO
            {
                OrderId = x.Id,
                ProductId = x.ProductId,
                ProductTitle = x.Product.Title,
                StoreName = x.Product.Seller.StoreName,
                ColorName = x.ProductColor.ColorName,
                Count = x.Count,
                ProductColorPrice = Convert.ToInt32(x.ProductColor.Price),
                ProductPrice = x.ProductPrice,
                OriginalProductPrice = x.Product.Price,
                MainProductPrice = (x.Product.Price + x.ProductColorPrice) * x.Count + x.ShippingPrice,
                ProductShippingPrice = x.ShippingPrice,
                ProductColorId = x.ProductColorId,
                ProductImage = x.Product.Image,


            }).ToList();


            foreach (var item in items)
            {
                item.DiscountPercentage = discount
                        .FirstOrDefault(x => x.ProductId == item.ProductId)?.Percentage;

                item.DiscountPrice = item.MainProductPrice - item.ProductPrice;

                item.ProductShippingPrice = Convert.ToInt32(shipping
                    .FirstOrDefault(x => x.ProductId == item.ProductId)?.TotalShippingPrice * item.Count);

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
            if (_userAddressRepository != null)
            {
                await _userAddressRepository.DisposeAsync();
            }
        }



        #endregion
    }
}
