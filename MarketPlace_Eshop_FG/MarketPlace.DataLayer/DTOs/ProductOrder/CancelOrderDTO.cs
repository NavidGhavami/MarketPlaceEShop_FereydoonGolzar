using System;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.ProductOrder
{
    public class CancelOrderDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات تایید / عدم تایید اطلاعات")]
        public string Description { get; set; }
        public string CancelOrderDate { get; set; }
        public string SuccessOrderDate { get; set; }


    }

    public enum CancelOrderResult
    {
        Success,
        OrderNotFound,
        Error,
    }
}
