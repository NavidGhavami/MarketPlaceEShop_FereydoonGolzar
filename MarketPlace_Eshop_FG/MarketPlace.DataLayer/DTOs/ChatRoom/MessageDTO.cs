using System;

namespace MarketPlace.DataLayer.DTOs.ChatRoom
{
    public  class MessageDTO
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
