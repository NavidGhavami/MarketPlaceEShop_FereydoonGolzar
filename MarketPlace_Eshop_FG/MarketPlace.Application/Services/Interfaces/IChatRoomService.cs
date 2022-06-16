using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlace.Application.Services.Interfaces
{
    public  interface IChatRoomService : IAsyncDisposable
    {
        Task<long> CreateChatRoom( string connectionId, long sellerId);
        Task<long> GetChatRoomForConnection( string connectionId);
        Task<List<long>> GetAllRooms(long sellerId);
    }
}
