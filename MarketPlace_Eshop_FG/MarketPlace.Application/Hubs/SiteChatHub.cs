using System;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.ChatRoom;
using MarketPlace.DataLayer.Entities.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace MarketPlace.Application.Hubs
{
    public class SiteChatHub : Hub
    {
        #region Constructor

        private readonly IChatRoomService _chatRoomService;
        private readonly IMessageService _messageService;
        private readonly ISellerService _sellerService;

        public SiteChatHub(IChatRoomService chatRoomService, IMessageService messageService, ISellerService sellerService)
        {
            _chatRoomService = chatRoomService;
            _messageService = messageService;
            _sellerService = sellerService;
        }

        #endregion

        public async Task SendNewMessage(string message)
        {

            var roomId = await _chatRoomService.GetChatRoomForConnection(Context.ConnectionId);

            var sender = Context.User.Identity.Name;

            var chatMessage = new MessageDTO
            {
                Message = message,
                Sender = sender,
                Time = DateTime.Now.ToShamsiDateTime()
            };

            await _messageService.SaveChatMessage(roomId, chatMessage);

            await Clients.Groups(roomId.ToString()).SendAsync("GetNewMessage", chatMessage.Sender, chatMessage.Message, chatMessage.Time);
        }

        /// <summary>
        /// پیوستن فروشنده ها به گروه
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>

        [Authorize]
        public async Task JoinRoom(long roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }


        /// <summary>
        /// ترک گروه توسط فروشنده
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>

        [Authorize]
        public async Task LeaveRoom(long roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        
        public override async Task OnConnectedAsync()
        {
            var seller = await _sellerService.GetLastActiveSellerByUserName(Context.User.Identity.Name);
            var roomId = await _chatRoomService.CreateChatRoom(Context.ConnectionId, seller.Id);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            await Clients.Caller.SendAsync("getNewMessage", "فروشنده جیبی سنتر", "سلام و وقت بخیر. در خدمتتان هستم. چطور میتوانم کمکتان کنم؟");
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
