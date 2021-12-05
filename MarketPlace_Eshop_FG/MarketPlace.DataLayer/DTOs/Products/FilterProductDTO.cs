using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Products;

namespace MarketPlace.DataLayer.DTOs.Products
{
    public class FilterProductDTO : BasePaging
    {
        #region Properties
        public string ProductTitle { get; set; }
        public long? SellerId { get; set; }
        public List<Product> Products { get; set; }
        public FilterProductState ProductState { get; set; }

        #endregion

        #region Methods

        public FilterProductDTO SetProduct(List<Product> products)
        {
            this.Products = products;
            return this;
        }

        public FilterProductDTO SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitesCount = paging.AllEntitesCount;
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

    public enum FilterProductState
    {
        [Display(Name = "همه")]
        All,

        [Display(Name = "درحال بررسی")]
        UnderProgress,

        [Display(Name = "تایید شده")]
        Accepted,

        [Display(Name = "رد شده")]
        Rejected,

        [Display(Name = "فعال")]
        Active,

        [Display(Name = "غیرفعال")]
        NotActive
    }

    public enum FilterProductOrder
    {
        CreateDateDescending,
        CreateDateAscending,

    }
}
