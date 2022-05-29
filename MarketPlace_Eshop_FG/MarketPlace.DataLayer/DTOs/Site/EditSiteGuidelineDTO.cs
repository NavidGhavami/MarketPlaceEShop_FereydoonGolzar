namespace MarketPlace.DataLayer.DTOs.Site
{
    public  class EditSiteGuidelineDTO : CreateSiteGuidelineDTO
    {
        public long Id { get; set; }

        public enum EditSiteGuidelineResult
        {
            Success,
            NotFound,
            Error
        }
    }
}
