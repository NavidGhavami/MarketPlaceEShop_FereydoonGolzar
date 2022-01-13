using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Common
{
    public class RejectItemDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات تایید / عدم تایید اطلاعات")]
        public string RejectMessage { get; set; }
    }

}
