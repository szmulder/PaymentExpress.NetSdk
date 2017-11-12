# PaymentExpress

Support the pxpay2.0 solution
http://www.paymentexpress.com/document/pxecom_pxpay_2_0_integrationguide.pdf


## Instructions

### How to use it
```c

using PaymentExpressProxy;


public class PaymentProvider
    {
		/// <summary>
        /// In the PaymentSuccess page, call this method
		/// var paymentResponseModel = default(PaymentResponseModel);
        ///    //Get payment express result
        ///    string result = Request.QueryString["result"];
		///	   var paymentProvider = new PaymentProvider();
        ///    var response = paymentProvider.GetPaymentExpressResponse(result);
		///    if (response != null && response.Success)
        ///    {...
		/// </summary>
        /// <param name="entityInput"> Your Order detail.</param>
        /// <returns>Returns string object.</returns>
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

		/// <summary>
        /// Get GetPaymentExpress Host Url, and you need redirect to the Url
		/// </summary>
        /// <param name="entityInput"> Your Order detail.</param>
        /// <returns>Returns string object.</returns>
        public string GetPaymentExpressHostUrl(Order order)
        {
            string url = "";

			var paymentUrl = new PaymentUrl()
			{
				PaymentGatewayUrlSuccess = "PaymentSuccess Url",
				PaymentGatewayUrlFail = "PaymentFail Url"
			};

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
                EmailAddress = order.Email
            };

            url = paymentProxy.RequestUrl(generateRequest);

            return url;
        }
	|}

public class PaymentUrl
    {
        public string PaymentGatewayUrlSuccess { get; set; }

        public string PaymentGatewayUrlFail { get; set; }
    }

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