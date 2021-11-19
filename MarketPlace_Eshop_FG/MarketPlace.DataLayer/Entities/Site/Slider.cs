using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Common;

namespace MarketPlace.DataLayer.Entities.Site
{
    public class Slider : BaseEntity
    {

        #region Properties

        [Display(Name = "متن هدر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Header { get; set; }

        [Display(Name = "عنوان اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string MainText { get; set; }

        [Display(Name = "عنوان فرعی")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string SecondText { get; set; }

        [Display(Name = "تصویر اسلایدر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ImageName { get; set; }

        [Display(Name = "متن فوتر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Footer { get; set; }

        [Display(Name = "متن دکمه اسلایدر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Link { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }


        #endregion

    }
}
