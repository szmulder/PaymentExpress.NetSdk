using System.ComponentModel;

namespace PaymentExpressProxy
{
    public class Account
    {
        public string PosContentType = "application/x-www-form-urlencoded";
        public string UrlMethod = "POST";

        public string PaymentGatewayUrl { get; set; }
        public string PaymentGatewayUrlSuccess { get; set; }
        public string PaymentGatewayUrlFail { get; set; }
        public string PxPayUserId { get; set; }
        public string PxPayKey { get; set; }
    }

    public enum TxnType
    {
        Auth,
        Complete,
        Purchase,
        Refund
    }

    public enum Currency
    {
        [Description("Australian Dollar")]
        AUD,

        [Description("Hong Kong Dollar")]
        HKD,

        [Description("Singapore Dollar BND Brunei Dollar INR Indian Rupee THB Thai Baht")]
        SGD,

        [Description("Canadian Dollar")]
        CAD,
        
        [Description("Japanese Yen")]
        JPY,
        
        [Description("Tongan Pa'anga CHF Switzerland Franc KWD Kuwait Dinar USD United States Dollar")]
        TOP,
        
        [Description("Euro")]
        EUR,
        
        [Description("Malaysian Ringgit")]
        MYR,
        
        [Description("Vanuatu Vatu")]
        VUV,

        [Description("Fiji Dollar")]
        FJD,
        
        [Description("New Zealand Dollar")]
        NZD,

        [Description("Samoan Tala")]
        WST,
        
        [Description("French Franc")]
        FRF,
        
        [Description("Papua New Guinean Kina")]
        PGK,

        [Description("South African Rand")]
        ZAR,

        [Description("United Kingdom Pound ")]
        GBP,

        [Description("Solomon Islander Dollar")]
        SBD
        
    }
}
