namespace MarketPlace.DataLayer.DTOs.Account
{
    public class EditRoleDTO : CreateRoleDTO
    {
        public long Id { get; set; }
    }

    public enum EditRoleResult
    {
        Success,
        Error
    }
}
