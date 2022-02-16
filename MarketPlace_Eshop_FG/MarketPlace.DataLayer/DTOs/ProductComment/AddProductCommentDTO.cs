using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.ProductComment;

namespace MarketPlace.DataLayer.DTOs.ProductComment
{
    public class AddProductCommentDTO
    {
        #region Properties

        public long UserId { get; set; }
        public long ProductId { get; set; }

        [Display(Name = "نام و نام خانوادگی کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "نقاط قوت، نقاط ضعف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(650, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string CommentFeature { get; set; }

        [Display(Name = "متن دیدگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CommentText { get; set; }

        [Display(Name = "وضعیت")]
        public CommentAcceptanceState CommentAcceptanceState { get; set; }

        #endregion
    }

    public enum AddProductCommentResult
    {
        Success,
        Error
    }
}
