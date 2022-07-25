using System;
using System.Threading.Tasks;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IShippingService : IAsyncDisposable
    {
        #region Shipping

        Task<int> CalculateProductShipping(long productId);

        #endregion
    }
}
