using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.DTOs.Paging;

namespace MarketPlace.DataLayer.DTOs.SellerWallet
{
    public class FilterSellerWalletDTO : BasePaging
    {
        public long? SellerId { get; set; }
        public string StoreName { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public List<Entities.Wallet.SellerWallet> SellerWallets { get; set; }
        public FilterSellerWallet State { get; set; }


        public enum FilterSellerWallet
        {
            [Display(Name = "همه")]
            All,

            [Display(Name = "واریز")]
            Deposit,

            [Display(Name = "برداشت")]
            Withdraw,
        }



        #region Methods

        public FilterSellerWalletDTO SetSellerWallers(List<Entities.Wallet.SellerWallet> wallets)
        {
            SellerWallets = wallets;
            return this;
        }

        public FilterSellerWalletDTO SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.TakeEntity = paging.TakeEntity;
            this.SkipEntity = paging.SkipEntity;
            this.PageCount = paging.PageCount;

            return this;
        }

        #endregion
    }
}
