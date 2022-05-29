namespace MarketPlace.DataLayer.DTOs.Site
{
    public  class EditSellerGuidelineDTO : CreateSellerGuidelineDTO
    {
        public long Id { get; set; }

    }

    public enum EditSellerGuidelineResult
    {
        Success,
        NotFound,
        Error
    }
}
