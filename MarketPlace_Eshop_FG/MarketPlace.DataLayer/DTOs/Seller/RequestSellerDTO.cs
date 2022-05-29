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
        public string NationalCardImage { get; set; }

        [Display(Name = "تلفن ثابت فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Phone { get; set; }

        [Display(Name = "تلفن ثابت فروشگاه")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Mobile { get; set; }

        [Display(Name = "آدرس فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(650, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Address { get; set; }

        [Display(Name = "شماره حساب بانکی")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string BankAccountNumber { get; set; }

        [Display(Name = "شماره کارت بانکی")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string BankAccountCardNumber { get; set; }

        [Display(Name = "شماره شبا بانکی")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string BankAccountShabaNumber { get; set; }

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
