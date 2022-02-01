namespace MarketPlace.DataLayer.DTOs.Contact
{
    public class EditAboutUsDTO : CreateAboutUsDTO
    {
        public long Id { get; set; }
    }

    public enum EditAboutUsResult
    {
        Success, 
        NotFound,
        Error

    }
}
