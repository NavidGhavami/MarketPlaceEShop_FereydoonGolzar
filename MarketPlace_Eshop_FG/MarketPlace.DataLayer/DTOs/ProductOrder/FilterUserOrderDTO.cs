using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.ProductOrder;

namespace MarketPlace.DataLayer.DTOs.ProductOrder
{
    public class FilterUserOrderDTO : BasePaging
    {
        #region Constructor

        public FilterUserOrderDTO()
        {
            OrderBy = FilterUserOrder.CreateDateDescending;
        }

        #endregion

        #region Properties

        public long? UserId { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }

        [Display(Name = "کد پیگیری")]
        public string TrackingCode { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        public FilterUserOrderState FilterUserOrderState { get; set; }
        public FilterUserOrder OrderBy { get; set; }

        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        #endregion

        #region Methods

        public FilterUserOrderDTO SetUserOrders(List<Order> orders)
        {
            this.Orders = orders;
            return this;
        }

        public FilterUserOrderDTO SetUserOrderDetails(List<OrderDetail> orderDetails)
        {
            this.OrderDetails = orderDetails;
            return this;
        }

        public FilterUserOrderDTO SetPaging(BasePaging paging)
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

    public enum FilterUserOrderState
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

    public enum FilterUserOrder
    {
        CreateDateDescending,
        CreateDateAscending,

    }
}
