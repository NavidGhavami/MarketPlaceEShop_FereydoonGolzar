using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.ChatRoom;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.ChatRoom;
using MarketPlace.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class ChatRoomService : IChatRoomService
    {
        #region Constructor

        private readonly IGenericRepository<ChatRoom> _chatRoomRepository;

        public ChatRoomService(IGenericRepository<ChatRoom> chatRoomRepository)
        {
            _chatRoomRepository = chatRoomRepository;
        }

        #endregion



        #region Chat Room

        public async Task<long> CreateChatRoom(string connectionId, long sellerId)
        {
            var existChatRoom = await _chatRoomRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.ConnectionId == connectionId);

            if (existChatRoom != null)
            {
                return await Task.FromResult(existChatRoom.Id);
            }

            var newChatRoom = new ChatRoom
            {
                ConnectionId = connectionId,
                SellerId = sellerId

            };

            await _chatRoomRepository.AddEntity(newChatRoom);
            await _chatRoomRepository.SaveChanges();

            return await Task.FromResult(newChatRoom.Id);
        }

        public async Task<long> GetChatRoomForConnection(string connectionId)
        {
            var chatRoom = await _chatRoomRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.ConnectionId == connectionId);

            return await Task.FromResult(chatRoom.Id);
        }

        public async Task<List<long>> GetAllRooms(long sellerId)
        {
            var rooms = await _chatRoomRepository
                .GetQuery()
                .AsQueryable()
                .OrderByDescending(x => x.Id)
                .Include(x => x.ChatMessages)
                .Include(x => x.Seller)
                .Where(x => x.ChatMessages.Any() && x.Seller.Id == sellerId)
                .Select(x => x.Id)
                .ToListAsync();

            return await Task.FromResult(rooms);
        }

        public async Task<FilterChatRoomDTO> FilterChatRoom(FilterChatRoomDTO filter)
        {
            var query = _chatRoomRepository
                .GetQuery()
                .Include(x => x.ChatMessages)
                .Include(x => x.Seller)
                .Where(x => x.ChatMessages.Any())
                .AsQueryable();


            switch (filter.OrderBy)
            {
                case FilterChatRoomOrder.CreateDateAscending:
                    query = query.OrderBy(x => x.CreateDate);
                    break;
                case FilterChatRoomOrder.CreateDateDescending:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
            }



            #region Filter

            if (filter.ChatRoomId != null && filter.ChatRoomId != 0)
            {
                query = query.Where(x => x.Id == filter.ChatRoomId);
            }

            if (!string.IsNullOrEmpty(filter.StoreName))
            {
                query = query.Where(x => EF.Functions.Like(x.Seller.StoreName, $"%{filter.StoreName}%"));
            }

            #endregion

            #region Paging

            var ticketCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, ticketCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetPaging(pager).SetChatRoom(allEntities);
        }

        #endregion

        

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_chatRoomRepository != null)
            {
                await _chatRoomRepository.DisposeAsync();
            }
        }

        #endregion
    }
}
