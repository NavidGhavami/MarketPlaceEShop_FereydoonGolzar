using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Site
{
    public  class CreateSellerGuidelineDTO
    {
        #region Property

        [Display(Name = "عنوان سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(550, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string QuestionTitle { get; set; }

        [Display(Name = "پاسخ سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(550, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string AnswerTitle { get; set; }

        #endregion

        public enum CreateSellerGuidelineResult
        {
            Success,
            Error
        }
    }
}
