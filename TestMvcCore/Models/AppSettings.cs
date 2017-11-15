namespace TestMvcCore.Models
{
    public class AppSettings
    {
        public PaymentExpressSettings PaymentExpressSettings { get; set; }
    }

    public class PaymentExpressSettings
    {
        public string PxPayUserId { get; set; }

        public string PxPayKey { get; set; }

        public string RequestUrl { get; set; }
    }    
}
