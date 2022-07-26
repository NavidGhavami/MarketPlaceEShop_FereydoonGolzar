namespace MarketPlace.DataLayer.DTOs.Shipping
{
    public  class EditShippingTrackingCodeDTO : CreateShippingTrackingCodeDTO
    {
        public long Id { get; set; }
    }

    public enum EditShippingTrackingCodeResult
    {
        NotFound,
        Error,
        Success
    }
}
