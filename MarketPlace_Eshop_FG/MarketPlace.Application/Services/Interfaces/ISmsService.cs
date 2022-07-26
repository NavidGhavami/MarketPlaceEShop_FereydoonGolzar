using System.Threading.Tasks;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface ISmsService
    {
        Task SendVerificationSms(string mobile, string activationCode);
        Task SendRecoverPasswordSms(string mobile, string password);
        Task SendOrderTrackingCodeSms(string mobile, string userName, string trackingCode, string orderDate);
        Task SendShippingTrackingCode(string mobile, string userName, string shippingTrackingCode, string orderTrackingCode, string date);
    }
}
