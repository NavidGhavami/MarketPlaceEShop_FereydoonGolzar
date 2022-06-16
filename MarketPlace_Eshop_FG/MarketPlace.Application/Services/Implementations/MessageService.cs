using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.ChatRoom;
using MarketPlace.DataLayer.Entities.ChatRoom;
using MarketPlace.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public  class MessageService : IMessageService
    {
        #region Constructor

        private readonly IGenericRepository<ChatMessage> _chatMessageRepository;
        private readonly IGenericRepository<ChatRoom> _chatRoomRepository;

        public MessageService(IGenericRepository<ChatMessage> chatMessageRepository, IGenericRepository<ChatRoom> chatRoomRepository)
        {
            _chatMessageRepository = chatMessageRepository;
            _chatRoomRepository = chatRoomRepository;
        }

        #endregion

        public async Task SaveChatMessage(long roomId, MessageDTO message)
        {
            var room = await _chatRoomRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == roomId);

            var chatMessage = new ChatMessage
            {
                ChatRoom = room,
                Message = message.Message,
                Sender = message.Sender,

            };

            await _chatMessageRepository.AddEntity(chatMessage);
            await _chatRoomRepository.SaveChanges();
        }

        public async Task<List<MessageDTO>> GetChatMessage(long roomId)
        {
            var message = await _chatMessageRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.ChatRoomId == roomId)
                .Select(x => new MessageDTO
                {
                    Message =x.Message,
                    Sender = x.Sender,
                    Time = x.CreateDate

                })
                .OrderBy(x=>x.Time)
                .ToListAsync();


            return await Task.FromResult(message);
        }



        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_chatMessageRepository != null)
            {
                await _chatMessageRepository.DisposeAsync();
            }
        }

        #endregion
    }
}
