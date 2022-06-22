using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.ChatRoom;

namespace MarketPlace.Application.Services.Interfaces
{
    public  interface IChatRoomService : IAsyncDisposable
    {
        Task<long> CreateChatRoom( string connectionId, long sellerId);
        Task<long> GetChatRoomForConnection( string connectionId);
        Task<List<long>> GetAllRooms(long sellerId);
        Task<FilterChatRoomDTO> FilterChatRoom(FilterChatRoomDTO filter);

    }
}
