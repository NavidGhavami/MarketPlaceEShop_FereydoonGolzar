using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;

namespace MarketPlace.Application.Services.Implementations
{
    public class SmsService : ISmsService
    {
        private string apiKey = "5936313054782B733155475A4270484D7964396C664A31575042712F763834496A6875456D687A554266633D";


        public async Task SendVerificationSms(string mobile, string activationCode)
        {
            Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(apiKey);
            await api.VerifyLookup(mobile, activationCode, "VerifyWebsiteAccount");
        }

    }
}
