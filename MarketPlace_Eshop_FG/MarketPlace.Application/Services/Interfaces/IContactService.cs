using System;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Contact;
using MarketPlace.DataLayer.Entities.Contact;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IContactService : IAsyncDisposable
    {
        #region Contact and About Us

        Task<FilterContactUs> FilterContactUs(FilterContactUs filter);
        Task CreateContactUs(CreateContactUsDTO contact, string userIp, long? userId);

        Task<AboutUs> GetAboutUs();
        Task<CreateAboutUsResult> CreateAboutUs(CreateAboutUsDTO about, IFormFile aboutImage);
        Task<EditAboutUsDTO> GetAboutUsForEdit(long id);
        Task<EditAboutUsResult> EditAboutUs(EditAboutUsDTO edit, IFormFile aboutImage);

        #endregion

        #region Ticket



        Task<AddTicketResult> AddUserTicket(AddTicketDTO ticket, long userId);
        Task<FilterTicketDTO> FilterTickets(FilterTicketDTO filter);
        Task<TicketDetailDTO> GetTicketDetail(long ticketId, long userId);
        Task<TicketDetailDTO> GetAdminTicketDetail(long ticketId, long userId);
        Task<AnswerTicketResult> AnswerTicket(AnswerTicketDTO answer, long userId);
        Task<AnswerTicketResult> AdminAnswerTicket(AnswerTicketDTO answer, long userId);

        #endregion
    }
}
