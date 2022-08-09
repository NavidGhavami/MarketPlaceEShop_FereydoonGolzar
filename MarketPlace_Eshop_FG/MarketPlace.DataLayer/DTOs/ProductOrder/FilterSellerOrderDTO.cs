using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.ProductOrder;

namespace MarketPlace.DataLayer.DTOs.ProductOrder
{
    public class FilterSellerOrderDTO : BasePaging
    {

        #region Constructor

        public FilterSellerOrderDTO()
        {
            OrderBy = FilterSellerOrder.CreateDateDescending;
        }

        #endregion

        #region Properties

        public long? UserId { get; set; }
        public long SellerId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool IsPaid { get; set; }
        public string TrackingCode { get; set; }
        public string RefId { get; set; }
        public string Description { get; set; }
        public string ProductTitle { get; set; }
        public int Count { get; set; }
        public long? ProductColorId { get; set; }
        public int MainProductPrice { get; set; }
        public int ProductPrice { get; set; }
        public int ProductColorPrice { get; set; }
        public string ColorName { get; set; }
        public string ProductImage { get; set; }
        public string StoreName { get; set; }
        public int? DiscountPercentage { get; set; }
        public int DiscountPrice { get; set; }

        public FilterSellerOrderState FilterUserOrderState { get; set; }
        public FilterSellerOrder OrderBy { get; set; }

        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        #endregion



        #region Methods

        public FilterSellerOrderDTO SetSellerOrder(List<Order> orders)
        {
            this.Orders = orders;
            return this;
        }
        public FilterSellerOrderDTO SetSellerOrderDetails(List<OrderDetail> orderDetails)
        {
            this.OrderDetails = orderDetails;
            return this;
        }

        public FilterSellerOrderDTO SetPaging(BasePaging paging)
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

    public enum FilterSellerOrderState
    {
        [Display(Name = "همه")]
        All,

        [Display(Name = "پرداخت شده")]
        PaymentSuccessful,

        [Display(Name = "پرداخت نشده")]
        PaymentNotSuccessful,

        [Display(Name = "لغو شده")]
        PaymentCancel,

        [Display(Name = "درحال بررسی")]
        UnderProgress
    }

    public enum FilterSellerOrder
    {
        CreateDateDescending,
        CreateDateAscending,

    }
}

