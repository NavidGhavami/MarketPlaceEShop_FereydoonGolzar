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
        private readonly ISellerService _sellerService;

        public static long SellerId { get; set; }

        public ChatRoomService(IGenericRepository<ChatRoom> chatRoomRepository, ISellerService sellerService)
        {
            _chatRoomRepository = chatRoomRepository;
            _sellerService = sellerService;
        }

        #endregion



        #region Chat Room

        public async Task<long> CreateChatRoom(string connectionId, string username)
        {
            var existChatRoom = await _chatRoomRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.ConnectionId == connectionId);

            if (existChatRoom != null)
            {
                return await Task.FromResult(existChatRoom.Id);
            }


            var sellerId = GetSellerId(SellerId);

            var seller = await _sellerService.GetLastActiveSellerBySellerId(sellerId);



            var newChatRoom = new ChatRoom
            {
                ConnectionId = connectionId,
                SellerId = seller.Id,
                Username = username

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

        public async Task<FilterChatRoomDTO> GetUserChatroom(FilterChatRoomDTO filter, string username)
        {
            var query = _chatRoomRepository
                .GetQuery()
                .Include(x => x.ChatMessages)
                .Include(x => x.Seller)
                .Where(x => x.ChatMessages.Any() && x.Username.Replace(" ","") == username)
                .AsQueryable();


            switch (filter.OrderBy)
            {
                case FilterChatRoomOrder.CreateDateAscending:
                    query = query.OrderBy(x => x.CreateDate);
                    break;
            }



            #region Filter

            if (filter.ChatRoomId != null && filter.ChatRoomId != 0)
            {
                query = query.Where(x => x.Id == filter.ChatRoomId);
            }

            #endregion

            #region Paging

            var chatCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, chatCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetPaging(pager).SetChatRoom(allEntities);
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

            var chatCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, chatCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetPaging(pager).SetChatRoom(allEntities);
        }

        public long GetSellerId(long sellerId)
        {
            return SellerId = sellerId;
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
