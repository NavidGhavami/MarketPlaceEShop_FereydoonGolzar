using System;
using System.Collections.Generic;
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
        Task<int> GetTotalOrderPriceForPayment(long userId);
        Task PayOrderProductPriceToSeller(long userId, long refId, string trackingCode);
        Task<FilterUserOrderDTO> GetUserOrder(FilterUserOrderDTO filter);


        #endregion

        #region Order Details

        Task AddProductToOpenOrder(long userId, AddProductToOrderDTO order);
        Task<UserOpenOrderDTO> GetUserOpenOrderDetail(long userId);
        Task<bool> RemoveOrderDetail(long detailId, long userId);
        Task ChangeOrderDetailCount(long detailId, long userId, int count);
        Task<List<UserOrderDetailItemDTO>> GetUserOrderDetailItem(long orderId, long userId);

        #endregion
    }
}
