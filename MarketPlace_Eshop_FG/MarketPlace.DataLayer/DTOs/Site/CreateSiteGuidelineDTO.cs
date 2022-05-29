using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Site
{
    public  class CreateSiteGuidelineDTO
    {
        #region Properties

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(550, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Header { get; set; }

        [Display(Name = "متن اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(550, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Text { get; set; }

        [Display(Name = "آیکون")]
        [MaxLength(550, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Icon { get; set; }

        #endregion

        public enum CreateSiteGuidelineResult
        {
            Success,
            Error
        }
    }
}
