using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.DTOs.Products;
using MarketPlace.DataLayer.DTOs.SellerWallet;
using MarketPlace.DataLayer.Entities.Products;
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
            var query = _sellerWalletRepository
                .GetQuery()
                .Include(x => x.Seller)
                .AsQueryable();



            switch (filter.State)
            {
                case FilterSellerWalletDTO.FilterSellerWallet.All:
                    query = query.Where(x => !x.IsDelete);
                    break;
                case FilterSellerWalletDTO.FilterSellerWallet.Deposit:
                    query = query.Where(x => x.TransactionType == TransactionType.Deposit);
                    break;
                case FilterSellerWalletDTO.FilterSellerWallet.Withdraw:
                    query = query.Where(x => x.TransactionType == TransactionType.Withdrawal);
                    break;
            }

            if (filter.SellerId != null && filter.SellerId != 0)
            {
                query = query.Where(x => x.SellerId == filter.SellerId.Value);
            }

            if (!string.IsNullOrEmpty(filter.StoreName))
            {
                query = query.Where(x => EF.Functions.Like(x.Seller.StoreName, $"%{filter.StoreName}%"));
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

            var wallets = await query.Paging(pager).OrderByDescending(x=>x.CreateDate).ToListAsync();

            return filter.SetSellerWallers(wallets).SetPaging(pager);

        }

        public async Task AddWallet(SellerWallet wallet)
        {
            await _sellerWalletRepository.AddEntity(wallet);
            await _sellerWalletRepository.SaveChanges();
        }

        public async Task<bool> ChangeTransActionTypeInSellerWallet(long walletId)
        {
            var sellerWallet = await _sellerWalletRepository.GetEntityById(walletId);

            if (sellerWallet != null)
            {
                sellerWallet.TransactionType = TransactionType.Withdrawal;
                sellerWallet.Description += "(تراکنش تسویه گردید)";
                _sellerWalletRepository.EditEntity(sellerWallet);
                await _sellerWalletRepository.SaveChanges();

                return true;
            }

            return false;
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
