using System;
using System.Collections.Generic;
using MarketPlace.DataLayer.Entities.ChatRoom;

namespace MarketPlace.DataLayer.DTOs.ChatRoom
{
    public  class MessageDTO
    {
        public long ChatRoomNumber { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public List<ChatMessage> Messages { get; set; }
        public Entities.ChatRoom.ChatRoom ChatRoom { get; set; }
    }
}
