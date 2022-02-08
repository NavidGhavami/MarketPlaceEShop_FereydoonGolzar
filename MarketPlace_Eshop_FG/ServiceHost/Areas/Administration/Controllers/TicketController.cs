using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Contact;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.Administration.Controllers
{
    public class TicketController : AdminBaseController
    {
        #region Constructor

        private readonly IContactService _contactService;

        public TicketController(IContactService contactService)
        {
            _contactService = contactService;
        }

        #endregion

        #region Ticket List

        [HttpGet("ticket-list")]
        public async Task<IActionResult> TicketList(FilterTicketDTO filter)
        {
            filter.OrderBy = FilterTicketOrder.CreateDateDescending;

            var result = await _contactService.FilterTickets(filter);

            return View(result);
        }


        #endregion

        #region Ticket Detail in Admin


        [HttpGet("ticket-detail/{ticketId}")]
        public async Task<IActionResult> AdminTicketDetail(long ticketId)
        {
            var ticketDetail = await _contactService.GetAdminTicketDetail(ticketId, User.GetUserId());

            if (ticketDetail == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(ticketDetail);
        }

        #endregion

        #region Answer Admin Ticket

        [HttpPost("admin-answer-ticket"), ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminAnswerTicket(AnswerTicketDTO answerTicket)
        {

            if (string.IsNullOrEmpty(answerTicket.Text))
            {
                TempData[ErrorMessage] = "لطفا متن پیام خود را وارد نمایید";
            }

            if (ModelState.IsValid)
            {
                var result = await _contactService.AdminAnswerTicket(answerTicket, User.GetUserId());

                switch (result)
                {
                    case AnswerTicketResult.NotFound:
                        TempData[ErrorMessage] = "تیکت مورد نظر یافت نشد";
                        break;
                    case AnswerTicketResult.Success:
                        TempData[SuccessMessage] = "ثبت پاسخ برای تیکت مورد نظر با موفقیت انجام گردید";
                        break;
                }
            }


            return RedirectToAction("AdminTicketDetail", "Ticket", new { area = "Administration", ticketId = answerTicket.Id });


        }

        #endregion
    }
}
