using System;
using System.Xml.Serialization;

namespace PaymentExpressProxy
{
    [Serializable]
    [XmlRoot(ElementName = "Response")]
    public class TransactionResponse
    {
        #region "Public Properties"

        //public int PaymentexpressId { get; set; }

        //public int OrderId { get; set; }

        public bool Success { get; set; }

        public string TxnType { get; set; }

        public string CurrencyInput { get; set; }

        public string MerchantReference { get; set; }

        public string TxnData1 { get; set; }

        public string TxnData2 { get; set; }

        public string TxnData3 { get; set; }

        public string AuthCode { get; set; }

        public string CardName { get; set; }

        public string CardHolderName { get; set; }

        public string CardNumber { get; set; }

        public string CardNumber2 { get; set; }

        public string DateExpiry { get; set; }

        public string ClientInfo { get; set; }

        public string TxnId { get; set; }

        public string EmailAddress { get; set; }

        public string DpsTxnRef { get; set; }

        public string BillingId { get; set; }

        public string DpsBillingId { get; set; }

        public decimal AmountSettlement { get; set; }

        public string CurrencySettlement { get; set; }

        public string TxnMac { get; set; }

        public string Cvc2ResultCode { get; set; }
        #endregion
    }
}