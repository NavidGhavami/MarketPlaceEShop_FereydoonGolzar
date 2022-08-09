using System;

namespace MarketPlace.DataLayer.DTOs.Payment
{
    public class URLs
    {
        public const String GateWayUrl = "https://www.zarinpal.com/pg/StartPay/";
        public const String RequestUrl = "https://api.zarinpal.com/pg/v4/payment/request.json";
        public const String VerifyUrl = "https://api.zarinpal.com/pg/v4/payment/verify.json";


    }
}
