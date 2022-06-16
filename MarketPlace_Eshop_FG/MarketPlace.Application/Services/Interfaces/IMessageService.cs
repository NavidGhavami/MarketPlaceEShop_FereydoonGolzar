using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.ChatRoom;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IMessageService : IAsyncDisposable
    {
        Task SaveChatMessage(long roomId, MessageDTO message);
        Task<List<MessageDTO>> GetChatMessage(long roomId);
    }
}
