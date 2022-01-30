namespace MarketPlace.DataLayer.DTOs.Site
{
    public class EditSliderDTO : CreateSliderDTO
    {
        public long Id { get; set; }
    }

    public enum EditSliderResult
    {
        Success, 
        Error,
        NotFound,
    }
}
