namespace MarketPlace.DataLayer.DTOs.ProductOrder
{
    public class AddProductToOrderDTO
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
        public long? ProductColorId { get; set; }
        public long? ProductShippingId { get; set; }
    }
}
