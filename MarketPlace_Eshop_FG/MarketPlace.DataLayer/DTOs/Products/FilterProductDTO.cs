using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Products;

namespace MarketPlace.DataLayer.DTOs.Products
{
    public class FilterProductDTO : BasePaging
    {
        #region Constructor

        public FilterProductDTO()
        {
            OrderBy = FilterProductOrderBy.CreateDateDescending;
        }

        #endregion

        #region Properties

        public long ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string Category { get; set; }
        public long? SellerId { get; set; }
        public string StoreName { get; set; }
        public int FilterMinPrice { get; set; }
        public int FilterMaxPrice { get; set; }
        public int SelectedMinPrice { get; set; }
        public int SelectedMaxPrice { get; set; }
        public List<Product> Products { get; set; }
        public FilterProductState ProductState { get; set; }
        public FilterProductOrderBy OrderBy { get; set; }
        public List<long> SelectedProductCategories { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }

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

    public enum FilterProductOrderBy
    {
        [Display(Name = "جدیدترین")]
        CreateDateDescending,

        [Display(Name = "گرانترین")]
        PriceDescending,

        [Display(Name = "ارزانترین")]
        PriceAscending,

        [Display(Name = "بیشترین بازدید")]
        ViewDescending,

        [Display(Name = "کمترین بازدید")]
        ViewAscending,

        [Display(Name = "تاریخ (صعودی)")]
        CreateDateAscending,

    }
}
