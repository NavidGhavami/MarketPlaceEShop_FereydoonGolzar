using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.ProductDiscount
{
    public class CreateDiscountDTO
    {
        public long ProductId { get; set; }

        [Display(Name = "درصد تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Range(0, 100)]
        public int Percentage { get; set; }

        [Display(Name = "تاریخ انقضاء")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ExpireDate { get; set; }

        [Display(Name = "تعداد تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int DiscountNumber { get; set; }
    }
}
