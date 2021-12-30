using System.Collections.Generic;
using MarketPlace.DataLayer.DTOs.Paging;

namespace MarketPlace.DataLayer.DTOs.ProductDiscount
{
    public class FilterProductDiscountDTO : BasePaging
    {
        #region Properties

        public long? ProductId { get; set; }
        public long? SellerId { get; set; }
        public string ProductTitle { get; set; }
        public List<Entities.ProductDiscount.ProductDiscount> ProductDiscounts { get; set; }

        #endregion

        #region Methods

        public FilterProductDiscountDTO SetProductDiscount(List<Entities.ProductDiscount.ProductDiscount> productDiscounts)
        {
            this.ProductDiscounts = productDiscounts;
            return this;
        }

        public FilterProductDiscountDTO SetPaging(BasePaging paging)
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

    public enum CreateDiscountResult
    {
        Success,
        ProductIsNotForSeller,
        ProductNotFound,
        Error
    }

    
}
