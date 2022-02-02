using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Site
{
    public class CreatefrequentlyQuestionDTO
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

    public enum CreateFaqResult
    {
        Success,
        Error
    }
}
