using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace PaymentExpressProxy
{
    public class ProcessResponse
    {
        public string PxPayUserId;
        public string PxPayKey;
        public string Response;

        #region "Constructors"
        public ProcessResponse()
        {
        }

        public ProcessResponse(string pxPayUserId, string pxPayKey)
        {
            PxPayUserId = pxPayUserId;
            PxPayKey = pxPayKey;
        }

        public string ToXml()
        {
            var ms = new MemoryStream();

            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            var xsr = new XmlSerializer(typeof(ProcessResponse));
            xsr.Serialize(ms, this, xns);

            ms.Position = 0;
            return Encoding.UTF8.GetString(ms.ToArray());
        }
        #endregion
    }
}