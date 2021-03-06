namespace MarketPlace.DataLayer.DTOs.ProductOrder
{
    public class SellerOrderDetailItemDTO
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int Count { get; set; }
        public long? ProductColorId { get; set; }
        public int MainProductPrice { get; set; }
        public int ProductPrice { get; set; }
        public int ProductColorPrice { get; set; }
        public string ColorName { get; set; }
        public string ProductImage { get; set; }
        public string StoreName { get; set; }
        public int? DiscountPercentage { get; set; }
        public int DiscountPrice { get; set; }
    }
}
