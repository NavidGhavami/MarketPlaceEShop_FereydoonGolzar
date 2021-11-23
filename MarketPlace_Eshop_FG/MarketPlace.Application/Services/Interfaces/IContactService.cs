using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Contact;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IContactService
    {


        #region Ticket

        Task<AddTicketResult> AddUserTicket(AddTicketDTO ticket, long userId);
        Task<FilterTicketDTO> FilterTickets(FilterTicketDTO filter);
        Task<TicketDetailDTO> GetTicketDetail(long ticketId, long userId);
        Task<AnswerTicketResult> AnswerTicket(AnswerTicketDTO answer, long userId);

        #endregion
    }
}
