using System.Collections.Generic;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.ChatRoom;

namespace MarketPlace.DataLayer.DTOs.ChatRoom
{
    public  class FilterChatRoomDTO : BasePaging
    {
        #region Properties

        public long ChatRoomId { get; set; }
        public long SellerId { get; set; }
        public string StoreName { get; set; }
        public FilterChatRoomOrder OrderBy { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
        public List<Entities.ChatRoom.ChatRoom> ChatRooms { get; set; }


        #endregion

        #region Methods

        public FilterChatRoomDTO SetChatRoom(List<Entities.ChatRoom.ChatRoom> rooms)
        {
            this.ChatRooms = rooms;
            return this;
        }

        public FilterChatRoomDTO SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.TakeEntity = paging.TakeEntity;
            this.SkipEntity = paging.SkipEntity;
            this.PageCount = paging.PageCount;

            return this;
        }

        #endregion
    }

    public enum FilterChatRoomOrder
    {
        CreateDateDescending,
        CreateDateAscending,

    }
}
