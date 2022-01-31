namespace MarketPlace.DataLayer.DTOs.Site
{
    public class EditBannerDTO : CreateBannerDTO
    {
        #region Properties
        public long Id { get; set; }

        #endregion

    }

    public enum EditBannerResult
    {
        Success,
        Error
    }
}
