using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.ChatRoom;
using MarketPlace.DataLayer.DTOs.Contact;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.User.Controllers
{
    public class TicketController : UserBaseController
    {

        #region Constructor

        private readonly IUserService _userService;
        private readonly IContactService _contactService;
        private readonly IChatRoomService _chatRoomService;
        private readonly IMessageService _messageService;

        public TicketController(IContactService contactService, IChatRoomService chatRoomService,
            IUserService userService, IMessageService messageService)
        {
            _contactService = contactService;
            _chatRoomService = chatRoomService;
            _userService = userService;
            _messageService = messageService;
        }

        #endregion

        #region Ticket List

        [HttpGet("tickets")]
        public async Task<IActionResult> Index(FilterTicketDTO filter)
        {
            filter.UserId = User.GetUserId();
            filter.OrderBy = FilterTicketOrder.CreateDateDescending;

            var result = await _contactService.FilterTickets(filter);

            return View(result);
        }


        #endregion

        #region Add Ticket

        [HttpGet("add-ticket")]
        public async Task<IActionResult> AddTicket()
        {
            return View();
        }

        [HttpPost("add-ticket"), ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTicket(AddTicketDTO ticket)
        {
            if (ModelState.IsValid)
            {
                var result = await _contactService.AddUserTicket(ticket, User.GetUserId());

                switch (result)
                {
                    case AddTicketResult.Error:
                        TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                        break;
                    case AddTicketResult.Success:
                        TempData[SuccessMessage] = "تیکت شما با موفقیت ثبت شد";
                        TempData[InfoMessage] = "همکاران ما به زودی پاسخ شما را خواهند داد";
                        return RedirectToAction("Index", "Ticket");
                }
            }

            return View(ticket);
        }



        #endregion

        #region Show Ticket Details

        [HttpGet("tickets/{ticketId}")]
        public async Task<IActionResult> TicketDetail(long ticketId)
        {

            var ticket = await _contactService.GetTicketDetail(ticketId, User.GetUserId());

            if (ticket == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(ticket);
        }

        #endregion

        #region Answer Ticket

        [HttpPost("answer-ticket"), ValidateAntiForgeryToken]
        public async Task<IActionResult> AnswerTicket(AnswerTicketDTO answer)
        {
            if (string.IsNullOrEmpty(answer.Text))
            {
                TempData[ErrorMessage] = "لطفا متن پیام خود را وارد نمایید";
            }

            if (ModelState.IsValid)
            {
                var result = await _contactService.AnswerTicket(answer, User.GetUserId());

                switch (result)
                {
                    case AnswerTicketResult.NotForUser:
                        TempData[ErrorMessage] = "عدم دسترسی";
                        TempData[InfoMessage] = "درصورت تکرار این مورد، دسترسی شما به صورت کلی از سیستم قطع خواهد شد";
                        return RedirectToAction("Index");
                    case AnswerTicketResult.NotFound:
                        TempData[ErrorMessage] = "اطلاعات مورد نظر یافت نشد";
                        return RedirectToAction("Index");
                    case AnswerTicketResult.Success:
                        TempData[SuccessMessage] = "اطلاعات مورد نظر با موفقیت ثبت شد";
                        break;
                }
            }

            return RedirectToAction("TicketDetail", "Ticket", new { area = "User", ticketId = answer.Id });
        }

        #endregion

        #region User Conversation

        [HttpGet("user-conversation")]
        public async Task<IActionResult> GetUserConversation(FilterChatRoomDTO filter)
        {
            var user = await _userService.GetUserById(User.GetUserId());
            var username = user.FirstName + user.LastName;

            filter.OrderBy = FilterChatRoomOrder.CreateDateDescending;

            var result = await _chatRoomService.GetUserChatroom(filter, username);

            return View(result);
        }

        #endregion

        #region ChatRoom Details

        [HttpGet("conversation-detail/{conversationId}")]
        public async Task<IActionResult> ConversationDetail(long conversationId)
        {
            var roomMessage = await _messageService.GetMessageDetail(conversationId);

            if (roomMessage == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(roomMessage);

            #endregion


        }
    }
}
