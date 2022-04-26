using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MarketPlace.Application.Services.Implementations
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;


        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task SendVerificationSms(string mobile, string activationCode)
        {
            var apiKey = _configuration.GetSection("KavenegarSmsApiKey")["apiKey"];

            Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(apiKey);
            await api.VerifyLookup(mobile, activationCode, "VerifyWebsiteAccount");
        }

        public async Task SendRecoverPasswordSms(string mobile, string password)
        {
            var apiKey = _configuration.GetSection("KavenegarSmsApiKey")["apiKey"];

            Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(apiKey);
            await api.VerifyLookup(mobile, password, "VerifyRecoverPassword");
        }

        public async Task SendOrderTrackingCodeSms(string mobile, string userName, string trackingCode, string orderDate)
        {
            var apiKey = _configuration.GetSection("KavenegarSmsApiKey")["apiKey"];

            Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(apiKey);
            await api.VerifyLookup(mobile, userName, trackingCode, orderDate, "VerifyOrderTrackingCode");

        }
    }
}
