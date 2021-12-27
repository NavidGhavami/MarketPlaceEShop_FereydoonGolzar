using System;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.ProductOrder;
using MarketPlace.DataLayer.Entities.ProductOrder;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IOrderService : IAsyncDisposable
    {
        #region Order

        Task<long> AddOrderForUser(long userId);
        Task<Order> GetUserLatestOpenOrder(long userId);

        #endregion

        #region Order Details

        Task AddProductToOpenOrder(long userId, AddProductToOrderDTO order);
        Task<UserOpenOrderDTO> GetUserOpenOrderDetail(long userId);

        #endregion
    }
}
