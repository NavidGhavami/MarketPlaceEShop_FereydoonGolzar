using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Contact;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IContactService : IAsyncDisposable
    {


        #region Ticket

        Task<FilterContactUs> FilterContactUs(FilterContactUs filter);
        Task CreateContactUs(CreateContactUsDTO contact, string userIp, long? userId);

        Task<AddTicketResult> AddUserTicket(AddTicketDTO ticket, long userId);
        Task<FilterTicketDTO> FilterTickets(FilterTicketDTO filter);
        Task<TicketDetailDTO> GetTicketDetail(long ticketId, long userId);
        Task<AnswerTicketResult> AnswerTicket(AnswerTicketDTO answer, long userId);

        #endregion
    }
}
