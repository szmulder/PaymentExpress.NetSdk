using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace PaymentExpressProxy
{
    [Serializable]
    public class GenerateRequest
    {
        #region public

        public string PxPayUserId { get; set; }

        public string PxPayKey { get; set; }

        public TxnType TxnType { get; set; }

        public decimal AmountInput { get; set; }

        public Currency CurrencyInput { get; set; }

        public string MerchantReference { get; set; }

        public string TxnData1 { get; set; }

        public string TxnData2 { get; set; }

        public string TxnData3 { get; set; }

        public string EmailAddress { get; set; }

        public string TxnId { get; set; }

        public string BillingId { get; set; }

        public string EnableAddBillCard { get; set; }

        public string UrlFail { get; set; }

        public string UrlSuccess { get; set; }

        public string DpsBillingId { get; set; }

        public string Opt { get; set; }

        #endregion

        #region "Constructors"
        public GenerateRequest()
        {
        }

        public GenerateRequest(string pxPayUserId, string pxPayKey)
        {
            PxPayUserId = pxPayUserId;
            PxPayKey = pxPayKey;
        }

        public string ToXml()
        {
            var ms = new MemoryStream();

            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            var xsr = new XmlSerializer(typeof(GenerateRequest));
            xsr.Serialize(ms, this, xns);

            ms.Position = 0;
            return Encoding.UTF8.GetString(ms.ToArray());
        }
        #endregion
    }
}