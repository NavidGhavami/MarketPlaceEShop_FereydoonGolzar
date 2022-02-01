using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Contact
{
    public class CreateAboutUsDTO
    {
        #region properties

        [Display(Name = "متن درباره ما")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string AboutUsText { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string AboutUsImage { get; set; }

        [Display(Name = "سرویس 1")]
        public string Service1 { get; set; }

        [Display(Name = "عنوان سرویس 1")]
        public string ServiceSubject1 { get; set; }

        [Display(Name = "سرویس 2")]
        public string Service2 { get; set; }

        [Display(Name = "عنوان سرویس 2")]
        public string ServiceSubject2 { get; set; }

        [Display(Name = "سرویس 3")]
        public string Service3 { get; set; }

        [Display(Name = "عنوان سرویس 3")]
        public string ServiceSubject3 { get; set; }

        [Display(Name = "سرویس 4")]
        public string Service4 { get; set; }

        [Display(Name = "عنوان سرویس 4")]
        public string ServiceSubject4 { get; set; }

        [Display(Name = "سرویس 5")]
        public string Service5 { get; set; }

        [Display(Name = "عنوان سرویس 5")]
        public string ServiceSubject5 { get; set; }

        [Display(Name = "سرویس 6")]
        public string Service6 { get; set; }

        [Display(Name = "عنوان سرویس 6")]
        public string ServiceSubject6 { get; set; }

        #endregion
    }

    public enum CreateAboutUsResult
    {
        Success,
        Error
    }
}
