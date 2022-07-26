using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Common;
using MarketPlace.DataLayer.Entities.ProductOrder;

namespace MarketPlace.DataLayer.Entities.Shipping
{
    public  class ShippingTrackingCode : BaseEntity
    {
        #region Properties

        public long OrderId { get; set; }

        [Display(Name = "کد رهگیری پستی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string TrackingCode { get; set; }

        #endregion

        #region Relation

        public Order Order { get; set; }

        #endregion
    }

    
}
