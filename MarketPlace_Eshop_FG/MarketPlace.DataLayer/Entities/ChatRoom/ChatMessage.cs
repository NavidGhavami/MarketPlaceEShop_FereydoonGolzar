using MarketPlace.DataLayer.Entities.Common;

namespace MarketPlace.DataLayer.Entities.ChatRoom
{
    public  class ChatMessage : BaseEntity
    {
        #region Properties

        public long ChatRoomId { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }


        #region Relation

        public ChatRoom ChatRoom { get; set; }

        #endregion


        #endregion
    }
}
