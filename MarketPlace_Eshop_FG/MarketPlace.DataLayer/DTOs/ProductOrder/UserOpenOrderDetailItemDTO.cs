namespace MarketPlace.DataLayer.DTOs.ProductOrder
{
    public class UserOpenOrderDetailItemDTO
    {
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int Count { get; set; }
        public long? ProductColorId { get; set; }
        public int ProductPrice { get; set; }
        public int ProductColorPrice { get; set; }
        public string ColorName { get; set; }
        public string ProductImage { get; set; }
    }
}
