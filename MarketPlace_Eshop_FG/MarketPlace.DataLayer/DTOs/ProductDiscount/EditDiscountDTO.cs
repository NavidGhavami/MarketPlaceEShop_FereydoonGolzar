namespace MarketPlace.DataLayer.DTOs.ProductDiscount
{
    public class EditDiscountDTO : CreateDiscountDTO
    {
        public long Id { get; set; }
        public string ProductTitle { get; set; }
    }

    public enum EditDiscountResult
    {
        Success,
        ProductIsNotForSeller,
        ProductNotFound,
        Error
    }
}
