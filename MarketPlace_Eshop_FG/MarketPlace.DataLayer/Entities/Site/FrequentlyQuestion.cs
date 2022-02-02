using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Common;

namespace MarketPlace.DataLayer.Entities.Site
{
    public class FrequentlyQuestion : BaseEntity
    {
        #region Properties

        [Display(Name = "عنوان سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(550, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string QuestionHeader { get; set; }

        [Display(Name = "پاسخ سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string QuestionText { get; set; }

        #endregion
    }
}
