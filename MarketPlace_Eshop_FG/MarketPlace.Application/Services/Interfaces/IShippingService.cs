using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Shipping;
using MarketPlace.DataLayer.Entities.Shipping;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IShippingService : IAsyncDisposable
    {
        #region Shipping

        Task<int> CalculateProductShipping(long productId);
        Task<List<ShippingTrackingCode>> GetShippingTrackingCode(long orderId);
        Task<SendTrackingCodeResult> AddShippingTrackingCode(CreateShippingTrackingCodeDTO trackingCode, long orderId);
        Task<EditShippingTrackingCodeDTO> GetShippingTrackingCodeForEdit(long trackingCodeId);
        Task<EditShippingTrackingCodeResult> EditShippingTrackingCode(EditShippingTrackingCodeDTO tracking);

        #endregion
    }
}
