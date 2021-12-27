using System;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.ProductOrder;
using MarketPlace.DataLayer.Entities.ProductOrder;
using MarketPlace.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class OrderService : IOrderService
    {
        #region Constructor

        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;

        public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<OrderDetail> orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        #endregion


        #region Order

        public async Task<long> AddOrderForUser(long userId)
        {
            var order = new Order { UserId = userId };

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
                .SingleOrDefaultAsync(x => x.UserId == userId && !x.IsPaid);


            return userOpenOrder;
        }



        #endregion

        #region Order Details

        public async Task AddProductToOpenOrder(long userId, AddProductToOrderDTO order)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);

            var similarOrder = openOrder.OrderDetails.SingleOrDefault(x =>
                x.ProductId == order.ProductId && x.ProductColorId == order.ProductColorId);

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
                Details = userOpenOrder.OrderDetails.Select(x => new UserOpenOrderDetailItemDTO
                {
                    Count = x.Count,
                    ColorName = x.ProductColor?.ColorName,
                    ProductColorId = x.ProductColorId,
                    ProductColorPrice = x.ProductColor != null ? Convert.ToInt32(x.ProductColor.Price) : 0,
                    ProductId = x.ProductId,
                    ProductPrice = x.Product.Price,
                    ProductTitle = x.Product.Title,
                    ProductImage = x.Product.Image


                }).ToList()
            };
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
        }



        #endregion
    }
}
