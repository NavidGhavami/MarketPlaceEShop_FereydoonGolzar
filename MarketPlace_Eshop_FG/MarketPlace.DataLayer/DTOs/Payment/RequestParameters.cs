#nullable enable
namespace MarketPlace.DataLayer.DTOs.Payment
{
    public class RequestParameters
    {
        public string MerchantId { get; set; }

        public string Amount { get; set; }
        public string Description { get; set; }
        public string CallbackUrl { get; set; }

        public string? Mobile { get; set; }
        public string? Email { get; set; }

        public RequestParameters(string merchantId, string amount, string description, string callbackUrl, string? mobile, string? email)
        {
            this.MerchantId = merchantId;
            this.Amount = amount;
            this.Description = description;
            this.CallbackUrl = callbackUrl;
            this.Mobile = mobile;
            this.Email = email;


        }
    }
}
