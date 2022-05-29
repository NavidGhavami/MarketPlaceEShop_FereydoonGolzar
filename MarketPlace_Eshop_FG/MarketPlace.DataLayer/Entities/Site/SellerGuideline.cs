using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Common;

namespace MarketPlace.DataLayer.Entities.Site
{
    public  class SellerGuideline : BaseEntity
    {
        #region Property

        [Display(Name = "عنوان سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string QuestionTitle { get; set; }

        [Display(Name = "پاسخ سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string AnswerTitle { get; set; }

        #endregion
    }
}
