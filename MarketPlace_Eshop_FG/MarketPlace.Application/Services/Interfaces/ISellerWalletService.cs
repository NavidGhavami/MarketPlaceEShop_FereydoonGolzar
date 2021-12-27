using System;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.SellerWallet;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface ISellerWalletService : IAsyncDisposable
    {
        Task<FilterSellerWalletDTO> FilterSellerWallet(FilterSellerWalletDTO filter);
    }
}
