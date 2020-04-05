using System.Net;
using System.Text;
using System.Xml;

namespace PaymentExpress
{
    class Common
    {
        public static string GetNodeValue(XmlDocument doc, string name)
        {
            string r = "";
            XmlNodeList prices = doc.GetElementsByTagName(name);

            foreach (XmlNode price in prices)
            {
                r += price.ChildNodes[0].Value;
            }

            return r;
        }

        public static void AddXmlElement(string name, string elementValue, StringBuilder xmlString)
        {
            xmlString.Append("<");
            xmlString.Append(name);
            xmlString.Append(">");
            xmlString.Append(WebUtility.HtmlEncode(elementValue));
            xmlString.Append("</");
            xmlString.Append(name);
            xmlString.Append(">");
        }
    }
}
