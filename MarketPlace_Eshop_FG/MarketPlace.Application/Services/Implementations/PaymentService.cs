using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MarketPlace.Application.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        #region Constructor

        private readonly IConfiguration _configuration;

        public string Prefix { get; set; }

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        #endregion

        #region Payment

        public PaymentStatus CreatePaymentRequest(string merchantId, int amount, string description, string callbackUrl,
           ref string redirectUrl, string userEmail = null, string userMobile = null)
        {
            var prefix = _configuration.GetSection("Payment")["method"];

            var payment = new ZarinpalSandbox.Payment(amount);
            var result = payment.PaymentRequest(description, callbackUrl, userEmail, userMobile);
            

            if (result.Result.Status == (int)PaymentStatus.St100)
            {
                redirectUrl = $"https://{prefix}.zarinpal.com/pg/StartPay/" + result.Result.Authority;
                return (PaymentStatus)result.Result.Status;
            }

            return (PaymentStatus)result.Status;

        }

        public PaymentStatus PaymentVerification(string merchantId, string authority, int amount, ref long refId)
        {
            var payment = new ZarinpalSandbox.Payment(amount);
            var result = payment.Verification(authority).Result;
            refId = result.RefId;

            return (PaymentStatus)result.Status;
        }

        public string GetAuthorityCodeFromCallback(HttpContext context)
        {
            if (context.Request.Query["Status"] == "" ||
                context.Request.Query["Status"].ToString().ToLower() != "ok" ||
                context.Request.Query["Authority"] == "")
            {
                return null;
            }

            string authority = context.Request.Query["Authority"];

            return authority.Length == 36 ? authority : null;
        }

        #endregion


    }
}
