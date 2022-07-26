using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Shipping
{
    public class CreateShippingTrackingCodeDTO
    {
        #region Properties

        public long OrderId { get; set; }

        [Display(Name = "کد رهگیری پستی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string TrackingCode { get; set; }

        #endregion

    }

    public enum SendTrackingCodeResult
    {
        Success,
        Error,
        OrderNotFound
    }
}
