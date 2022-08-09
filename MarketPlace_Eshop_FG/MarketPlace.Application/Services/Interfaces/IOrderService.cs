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
        Task<string> GetOrderBy(long orderId);
        Task PayOrderProductPriceToSeller(long userId, long refId, string trackingCode);
        Task<FilterUserOrderDTO> GetUserOrder(FilterUserOrderDTO filter);
        Task<CancelOrderResult> CancelOrder(CancelOrderDTO cancel, long userId);
        Task<CancelOrderDTO> GetOrderForCancel(long orderId, long userId);
        Task<FilterSellerOrderDTO> GetOrderForSeller(FilterSellerOrderDTO filter);
        Task<AddUserAddressResult> AddUserAddress(UserAddressDTO address, long userId);
        Task<List<UserAddress>> GetAddressToUser(long userId);
        Task<UserAddressDTO> GetUserAddressForOrder(long orderId, long userId);
        Task<UserAddressDTO> GetExistUserAddress(long userId);
        Task<bool> AddOrderToNoneAuthenticatedUser(long userId);


        #endregion

        #region Order Details

        Task AddProductToOpenOrder(long userId, AddProductToOrderDTO order);
        Task<UserOpenOrderDTO> GetUserOpenOrderDetail(long userId);
        Task<bool> RemoveOrderDetail(long detailId, long userId);
        Task ChangeOrderDetailCount(long detailId, long userId, int count);
        Task<List<UserOrderDetailItemDTO>> GetUserOrderDetailItem(long orderId, long userId);
        Task<List<SellerOrderDetailItemDTO>> GetSellerOrderDetailItem(long orderId, long sellerId);



        #endregion
    }
}
