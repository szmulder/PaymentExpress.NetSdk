# PaymentExpress

Support the pxpay2.0 solution


## Instructions

### How to use it
```c
public class PaymentProvider
    {
        public TransactionResponse GetPaymentExpressResponse(string result)
        {
            var paymentExpressSetting = new PaymentExpressSetting();
            var paymentProxy = new PaymentProxy()
            {
                Account = new Account()
                {
                    PaymentGatewayUrl = Settings.PaymentExpressPxPay20RequestUrl,
                    PxPayUserId = paymentExpressSetting.PxPayUserId,
                    PxPayKey = paymentExpressSetting.PxPayKey
                }
            };

            return paymentProxy.GetResponse(result);
        }

        public string GetPaymentExpressHostUrl(PaymentUrl paymentUrl, Order order)
        {
            string url = "";

            var paymentExpressSetting = new PaymentExpressSetting();
            var paymentProxy = new PaymentProxy()
            {
                Account = new Account()
                {
                    PaymentGatewayUrl = Settings.PaymentExpressPxPay20RequestUrl,
                    PxPayUserId = paymentExpressSetting.PxPayUserId,
                    PxPayKey = paymentExpressSetting.PxPayKey,
                    PaymentGatewayUrlSuccess = paymentUrl.PaymentGatewayUrlSuccess,
                    PaymentGatewayUrlFail = paymentUrl.PaymentGatewayUrlFail
                }
            };

            var generateRequest = new GenerateRequest()
            {
                TxnType = TxnType.Purchase,
                AmountInput = order.TotalPrice,
                CurrencyInput = Currency.NZD,
                MerchantReference = order.OrderId.ToString(),
                TxnData1 = order.BillingName,
                TxnData2 = order.BillingPhone,
                TxnData3 = order.UserId.ToString(),
                EmailAddress = order.User.Email
            };

            url = paymentProxy.RequestUrl(generateRequest);

            return url;
        }
	|}

public class PaymentExpressSetting
    {
        public PaymentExpressSetting()
        {
            EnableOnlinePayment = false;
            AdditionalFeePercentage = 0.03;
            AdditionalFeeFixCharge = 0;
            PxPayUserId = "put-your-PxPay-userId";
            PxPayKey = "put-your-PxPay-Key";
        }

        [Display(Name = "Enable Online Payment")]
        public bool EnableOnlinePayment { get; set; }

        [Display(Name = "Percentage of total amount")]
        public double AdditionalFeePercentage { get; set; }

        [Display(Name = "Fix Charge Fee")]
        public double AdditionalFeeFixCharge { get; set; }

        public string PxPayUserId { get; set; }

        public string PxPayKey { get; set; }
    }
```