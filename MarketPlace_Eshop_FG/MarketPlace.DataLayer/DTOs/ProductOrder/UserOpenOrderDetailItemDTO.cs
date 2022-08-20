namespace MarketPlace.DataLayer.DTOs.ProductOrder
{
    public class UserOpenOrderDetailItemDTO
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long? ProductColorId { get; set; }
        public long? ProductShippingId { get; set; }
        public string ProductTitle { get; set; }
        public int Count { get; set; }
        public int ProductPrice { get; set; }
        public int ProductColorPrice { get; set; }
        public int ProductShippingPrice { get; set; }
        public string ColorName { get; set; }
        public string ProductImage { get; set; }
        public int? DiscountPercentage { get; set; }
        public int? DiscountNumber { get; set; }
        public int? DiscountUseNumber { get; set; }
        public int StockCount { get; set; }
    }
}
