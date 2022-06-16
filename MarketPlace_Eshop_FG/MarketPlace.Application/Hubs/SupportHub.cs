using System;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.ChatRoom;
using Microsoft.AspNetCore.SignalR;

namespace MarketPlace.Application.Hubs
{

    
    public class SupportHub : Hub
    {
        #region Constructor

        private readonly IChatRoomService _chatRoomService;
        private readonly IMessageService _messageService;
        private readonly ISellerService _sellerService;

        private readonly IHubContext<SiteChatHub> _siteChatHub;


        public SupportHub(IChatRoomService chatRoomService, IMessageService messageService, IHubContext<SiteChatHub> siteChatHub, ISellerService sellerService)
        {
            _chatRoomService = chatRoomService;
            _messageService = messageService;
            _siteChatHub = siteChatHub;
            _sellerService = sellerService;
        }

        #endregion

        public override async Task OnConnectedAsync()
        {
            var seller = await _sellerService.GetLastActiveSellerByUserName(Context.User.Identity.Name);
            var rooms = await _chatRoomService.GetAllRooms(seller.Id);
            await Clients.Caller.SendAsync("GetRooms", rooms);
            await base.OnConnectedAsync();
        }


        public async Task LoadMessage(long roomId)
        {
            var message = await _messageService.GetChatMessage(roomId);
            await Clients.Caller.SendAsync("getNewMessage", message);
        }

        public async Task SupportSendMessage(long roomId, string message)
        {
            var supportMessage = new MessageDTO
            {
                Sender = Context.User.Identity.Name,
                Message = message,
                Time = DateTime.Now.ToShamsiDateTime()
            };

            await _messageService.SaveChatMessage(roomId, supportMessage);

            await _siteChatHub.Clients.Group(roomId.ToString())
                .SendAsync("getNewMessage", supportMessage.Sender, supportMessage.Message, supportMessage.Time);

        }
    }
}
