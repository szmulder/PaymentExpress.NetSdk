using Microsoft.Extensions.Options;
using PaymentExpressProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMvcCore.Models;

namespace TestMvcCore.Repository
{
    public class PaymentProvider
    {
        private readonly PaymentExpressSettings _appSettings;

        public PaymentProvider(IOptions<PaymentExpressSettings> optionsAccessor)
        {
            _appSettings = optionsAccessor.Value;
        }
        public TransactionResponse GetPaymentExpressResponse(string result)
        {
            var paymentProxy = new PaymentProxy()
            {
                Account = new Account()
                {
                    PaymentGatewayUrl = _appSettings.RequestUrl,
                    PxPayUserId = _appSettings.PxPayUserId,
                    PxPayKey = _appSettings.PxPayKey
                }
            };

            return paymentProxy.GetResponse(result);
        }

        public string GetPaymentExpressHostUrl(PaymentUrl paymentUrl, Order order)
        {
            string url = "";

            var paymentProxy = new PaymentProxy()
            {
                Account = new Account()
                {
                    PaymentGatewayUrl = _appSettings.RequestUrl,
                    PxPayUserId = _appSettings.PxPayUserId,
                    PxPayKey = _appSettings.PxPayKey,
                    PaymentGatewayUrlSuccess = paymentUrl.Success,
                    PaymentGatewayUrlFail = paymentUrl.Fail
                }
            };

            var generateRequest = new GenerateRequest()
            {
                TxnType = TxnType.Purchase,
                AmountInput = (decimal)order.Total,
                CurrencyInput = Currency.NZD,
                MerchantReference = order.OrderId.ToString(),
                TxnData1 = order.UserName,
                //TxnData2 = order.UserId.ToString(),
                //TxnData3 = order.SubTotal.ToString(),
                EmailAddress = order.UserEmail
            };

            url = paymentProxy.RequestUrl(generateRequest);

            return url;
        }
    }
}
