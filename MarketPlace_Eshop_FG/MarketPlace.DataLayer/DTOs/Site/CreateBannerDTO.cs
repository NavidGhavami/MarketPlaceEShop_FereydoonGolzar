using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Site;

namespace MarketPlace.DataLayer.DTOs.Site
{
    public class CreateBannerDTO
    {
        #region Properties

        [Display(Name = "متن هدر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Header { get; set; }

        [Display(Name = "متن اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string MainText { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ImageName { get; set; }

        [Display(Name = "آدرس بنر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Url { get; set; }

        [Display(Name = "متن دکمه آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string BtnText { get; set; }

        [Display(Name = "سایز بندی تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ColSize { get; set; }

        public SiteBanner.BannersLocations BannersLocation { get; set; }
        public enum BannersLocations
        {
            Home1,
            Home2,
            Home3
        }

        #endregion
    }
    public enum CreateBannerResult
    {
        Success,
        Error
    }
}
