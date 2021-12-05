using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Seller
{
    public class RequestSellerDTO
    {
        [Display(Name = "نام فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string StoreName { get; set; }

        [Display(Name = "کد ملّی فروشنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string NationalId { get; set; }

        [Display(Name = "تصویر کارت ملّی فروشنده")]
        [Required(ErrorMessage = "لطفا {0} را آپلود کنید")]
        public string NationalCardImage { get; set; }

        [Display(Name = "تلفن ثابت فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Phone { get; set; }

        [Display(Name = "آدرس فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(650, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Address { get; set; }

        [Display(Name = "لوگو فروشگاه")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Logo { get; set; }

        [Display(Name = "توضیحات فروشگاه")]
        public string Description { get; set; }

        [Display(Name = "یادداشت های ادمین")]
        public string AdminDescription { get; set; }

    }

    public enum RequestSellerResult
    {
        Success,
        HasUnderProgressRequest,
        HasNotPermission,

    }
}
