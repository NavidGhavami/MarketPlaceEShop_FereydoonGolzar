﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.DTOs.Paging;

namespace MarketPlace.DataLayer.DTOs.Seller
{
    public class FilterSellerDTO : BasePaging
    {

        #region Properties

        public long? UserId { get; set; }
        public string StoreName { get; set; }
        public string NationalId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public string NationalCardImage { get; set; }
        public FilterSellerState FilterSellerState { get; set; }
        public FilterSellerOrder OrderBy { get; set; }
        public List<Entities.Store.Seller> Sellers { get; set; }

        #endregion





        #region Methods

        public FilterSellerDTO SetSellers(List<Entities.Store.Seller> sellers)
        {
            this.Sellers = sellers;
            return this;
        }

        public FilterSellerDTO SetPaging(BasePaging paging)
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

    public enum FilterSellerState
    {
        [Display(Name = "همه")]
        All,

        [Display(Name = "درحال بررسی")]
        UnderProgress,

        [Display(Name = "تایید شده")]
        Accepted,

        [Display(Name = "رد شده")]
        Rejected
    }

    public enum FilterSellerOrder
    {
        CreateDateDescending,
        CreateDateAscending,

    }
    
}
