using System.Collections.Generic;
using MarketPlace.DataLayer.Entities.Common;
using MarketPlace.DataLayer.Entities.Store;

namespace MarketPlace.DataLayer.Entities.ChatRoom
{
    public  class ChatRoom : BaseEntity
    {
        #region Properties

        public long SellerId { get; set; }
        public string ConnectionId { get; set; }
        public string Username { get; set; }
        

        #endregion

        #region Relation

        public Seller Seller { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }

        #endregion
    }
}
