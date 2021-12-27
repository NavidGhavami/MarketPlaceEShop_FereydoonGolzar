using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.DTOs.SellerWallet;
using MarketPlace.DataLayer.Entities.Wallet;
using MarketPlace.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class SellerWalletService : ISellerWalletService
    {

        #region Constructor

        private readonly IGenericRepository<SellerWallet> _sellerWalletRepository;

        public SellerWalletService(IGenericRepository<SellerWallet> sellerWalletRepository)
        {
            _sellerWalletRepository = sellerWalletRepository;
        }


        #endregion


        #region Seller Wallet


        public async Task<FilterSellerWalletDTO> FilterSellerWallet(FilterSellerWalletDTO filter)
        {
            var query = _sellerWalletRepository.GetQuery().AsQueryable();

            if (filter.SellerId != null && filter.SellerId != 0)
            {
                query = query.Where(x => x.SellerId == filter.SellerId.Value);
            }

            if (filter.PriceFrom != null)
            {
                query = query.Where(x => x.Price >= filter.PriceFrom.Value);
            }
            if (filter.PriceTo != null)
            {
                query = query.Where(x => x.Price <= filter.PriceTo.Value);
            }

            var allEntitiesCount = await query.CountAsync();
            var pager = Pager.Build(filter.PageId, allEntitiesCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var wallets = await query.Paging(pager).ToListAsync();

            return filter.SetSellerWallers(wallets).SetPaging(pager);

        }

        #endregion


        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_sellerWalletRepository != null)
            {
                await _sellerWalletRepository.DisposeAsync();
            }
        }


        #endregion
    }
}
