﻿using System;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.ChatRoom;
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
        private readonly IUserService _userService;

        public long SellerId;

        public SiteChatHub(IChatRoomService chatRoomService, IMessageService messageService, ISellerService sellerService, IUserService userService)
        {
            _chatRoomService = chatRoomService;
            _messageService = messageService;
            _sellerService = sellerService;
            _userService = userService;
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
           
            var roomId = await _chatRoomService.CreateChatRoom(Context.ConnectionId, Context.User.Identity.Name);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            await Clients.Caller.SendAsync("getNewMessage", "فروشنده جیبی سنتر", "سلام و وقت بخیر. در خدمتتان هستم. چطور میتوانم کمکتان کنم؟","لطفا تا پایان مکالمه این صفحه را ترک ننمایید");
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
