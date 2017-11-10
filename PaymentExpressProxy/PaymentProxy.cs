using System;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using System.Xml;

namespace PaymentExpressProxy
{
    public class PaymentProxy
    {
        public Account Account { get; set; }

        public PaymentProxy()
        {
            Account = new Account();
        }

        public PaymentProxy(string pxPayUserId, string pxPayKey, string successUrl, string failUrl)
        {
            Account = new Account
            {
                PxPayUserId = pxPayUserId,
                PxPayKey = pxPayKey,
                PaymentGatewayUrlSuccess = successUrl,
                PaymentGatewayUrlFail = failUrl
            };
        }

        public string RequestUrl(GenerateRequest generateRequest)
        {
            string returnResult = String.Empty;
            generateRequest.PxPayUserId = Account.PxPayUserId;
            generateRequest.PxPayKey = Account.PxPayKey;
            generateRequest.UrlSuccess = Account.PaymentGatewayUrlSuccess;
            generateRequest.UrlFail = Account.PaymentGatewayUrlFail;

            var webReq = (HttpWebRequest)WebRequest.Create(Account.PaymentGatewayUrl);
            webReq.Method = Account.UrlMethod;

            byte[] reqBytes = null;
            reqBytes = Encoding.UTF8.GetBytes(generateRequest.ToXml().ToString());
            webReq.ContentType = Account.PosContentType;
            //webReq.ContentLength = reqBytes.Length;
            Stream requestStream = webReq.GetRequestStreamAsync().Result;
            requestStream.Write(reqBytes, 0, reqBytes.Length);
            requestStream.Dispose();

            var webResponse = (HttpWebResponse)webReq.GetResponseAsync().Result;
            var responseStream = webResponse.GetResponseStream();
            if (responseStream != null)
            {
                var streamReader = new StreamReader(responseStream, Encoding.ASCII);

                string pxRequest = streamReader.ReadToEnd();
                streamReader.Dispose();

                var doc = new XmlDocument();
                doc.LoadXml(pxRequest.Replace("&", "&amp;"));

                var processResponse = new ProcessResponse();
                if (pxRequest.IndexOf("valid=\"1\"") > 0)
                {
                    processResponse.Response = WebUtility.UrlDecode(doc.InnerText);
                    returnResult = processResponse.Response.Replace("&amp;", "&");
                }
            }

            return returnResult;
        }

        public TransactionResponse GetResponse(string result)
        {
            var transactionResponse = new TransactionResponse();

            var processResponse = new ProcessResponse(Account.PxPayUserId, Account.PxPayKey);
            processResponse.Response = result;

            var webReq = (HttpWebRequest)WebRequest.Create(Account.PaymentGatewayUrl);
            webReq.Method = Account.UrlMethod;

            byte[] reqBytes = null;
            reqBytes = Encoding.UTF8.GetBytes(processResponse.ToXml());
            webReq.ContentType = Account.PosContentType;
            //webReq.ContentLength = reqBytes.Length;
            var requestStream = webReq.GetRequestStreamAsync().Result;
            requestStream.Write(reqBytes, 0, reqBytes.Length);
            requestStream.Dispose();

            var webResponse = (HttpWebResponse)webReq.GetResponseAsync().Result;
            var responseStream = webResponse.GetResponseStream();

            if (responseStream != null)
            {
                var streamReader = new StreamReader(responseStream, Encoding.ASCII);

                string pxRequest = streamReader.ReadToEnd();
                streamReader.Dispose();

                var x = new XmlSerializer(typeof(TransactionResponse));
                transactionResponse = (TransactionResponse)x.Deserialize(new StringReader(pxRequest));               
            }

            return transactionResponse;
        }
    }
}