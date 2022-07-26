using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Shipping;
using MarketPlace.DataLayer.Entities.Shipping;
using MarketPlace.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class ShippingService : IShippingService
    {
        #region Constructor

        private readonly IGenericRepository<Shipping> _shippingRepository;
        private readonly IGenericRepository<ShippingTrackingCode> _shippingTrackingCodeRepository;

        public ShippingService(IGenericRepository<Shipping> shippingRepository, IGenericRepository<ShippingTrackingCode> shippingTrackingCodeRepository)
        {
            _shippingRepository = shippingRepository;
            _shippingTrackingCodeRepository = shippingTrackingCodeRepository;
        }

        #endregion

        public async Task<int> CalculateProductShipping(long productId)
        {
            var shipping = await _shippingRepository
                .GetQuery()
                .AsQueryable()
                .Include(x => x.Product)
                .SingleOrDefaultAsync(x => x.ProductId == productId);

            var coefficientPrice = 5000;


            shipping.TotalShippingPrice = shipping.Product.Weight switch
            {
                > 0 and <= 500 => shipping.BaseShippingPrice + 0,
                > 500 and <= 1000 => shipping.BaseShippingPrice + (coefficientPrice * 1),
                > 1000 and <= 2000 => shipping.BaseShippingPrice + (coefficientPrice * 2),
                > 2000 and <= 3000 => shipping.BaseShippingPrice + (coefficientPrice * 3),
                > 3000 and <= 4000 => shipping.BaseShippingPrice + (coefficientPrice * 4),
                > 4000 and <= 5000 => shipping.BaseShippingPrice + (coefficientPrice * 5),
                > 5000 and <= 6000 => shipping.BaseShippingPrice + (coefficientPrice * 6),
                > 6000 and <= 7000 => shipping.BaseShippingPrice + (coefficientPrice * 7),
                > 7000 and <= 8000 => shipping.BaseShippingPrice + (coefficientPrice * 8),
                > 8000 and <= 9000 => shipping.BaseShippingPrice + (coefficientPrice * 9),
                > 9000 and <= 10000 => shipping.BaseShippingPrice + (coefficientPrice * 10),
                > 10000 and <= 11000 => shipping.BaseShippingPrice + (coefficientPrice * 11),
                > 11000 and <= 12000 => shipping.BaseShippingPrice + (coefficientPrice * 12),
                > 12000 and <= 13000 => shipping.BaseShippingPrice + (coefficientPrice * 13),
                > 13000 and <= 14000 => shipping.BaseShippingPrice + (coefficientPrice * 14),
                > 14000 and <= 15000 => shipping.BaseShippingPrice + (coefficientPrice * 15),
                > 15000 and <= 16000 => shipping.BaseShippingPrice + (coefficientPrice * 16),
                > 16000 and <= 17000 => shipping.BaseShippingPrice + (coefficientPrice * 17),
                > 17000 and <= 18000 => shipping.BaseShippingPrice + (coefficientPrice * 18),
                > 18000 and <= 19000 => shipping.BaseShippingPrice + (coefficientPrice * 19),
                > 19000 and <= 20000 => shipping.BaseShippingPrice + (coefficientPrice * 20),
                > 20000 and <= 50000 => shipping.BaseShippingPrice + (coefficientPrice * 100),
                _ => shipping.TotalShippingPrice
            };

            return shipping.TotalShippingPrice;
        }

        public async Task<List<ShippingTrackingCode>> GetShippingTrackingCode(long orderId)
        {
            return await _shippingTrackingCodeRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<SendTrackingCodeResult> AddShippingTrackingCode(CreateShippingTrackingCodeDTO trackingCode, long orderId)
        {
            
            if (orderId > 0)
            {
                var newTrackingCode = new ShippingTrackingCode
                {
                    OrderId = trackingCode.OrderId,
                    TrackingCode = trackingCode.TrackingCode
                };

                await _shippingTrackingCodeRepository.AddEntity(newTrackingCode);
                await _shippingTrackingCodeRepository.SaveChanges();

                return SendTrackingCodeResult.Success;
            }

            return SendTrackingCodeResult.Error;

        }

        public async Task<EditShippingTrackingCodeDTO> GetShippingTrackingCodeForEdit(long trackingCodeId)
        {
            var trackingCode = await _shippingTrackingCodeRepository.GetEntityById(trackingCodeId);

            if (trackingCode == null)
            {
                return null;
            }

            return new EditShippingTrackingCodeDTO
            {
                Id = trackingCodeId,
                OrderId = trackingCode.OrderId,
                TrackingCode = trackingCode.TrackingCode
            };

        }

        public async Task<EditShippingTrackingCodeResult> EditShippingTrackingCode(EditShippingTrackingCodeDTO tracking)
        {
            var mainShippingTracking = await _shippingTrackingCodeRepository
                .GetQuery()
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == tracking.Id);

            if (mainShippingTracking == null)
            {
                return EditShippingTrackingCodeResult.NotFound;
            }

            mainShippingTracking.Id = tracking.Id;
            mainShippingTracking.OrderId = tracking.OrderId;
            mainShippingTracking.TrackingCode = tracking.TrackingCode;

            await _shippingTrackingCodeRepository.SaveChanges();


            return EditShippingTrackingCodeResult.Success;
        }


        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_shippingRepository != null)
            {
                await _shippingRepository.DisposeAsync();
            }
        }

        #endregion
    }
}



