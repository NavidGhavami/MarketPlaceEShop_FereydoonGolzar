namespace MarketPlace.DataLayer.DTOs.Wishlist
{
    public class WishlistDTO
    {
        public long Id { get; set; }
        public string ProductTitle { get; set; }
        public string StoreName { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
