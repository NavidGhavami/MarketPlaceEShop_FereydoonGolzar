using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Contact
{
    public class AnswerTicketDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Text { get; set; }
    }

    public enum AnswerTicketResult
    {
        NotForUser,
        NotFound,
        Success
    }
}
