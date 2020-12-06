using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace NavigationChallenge.Models
{
    public static class OrderModel
    {
        public static string GetNodeValue(XDocument doc, string nodePath, string elementName)
        {
            if (doc == null || string.IsNullOrEmpty(elementName) || string.IsNullOrEmpty(nodePath))
            {
                return "Parameters Missing";
            }
            try
            {
                string baseNode = "Orders/Order/";
                var element = doc.XPathSelectElement($"{baseNode}{nodePath}");
                return element.Element(elementName)?.Value;
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static T GetNodeValue<T>(XElement node, string nodeName)
        {
            var item = node.Element(nodeName)?.Value;
            return (T)Convert.ChangeType(item, typeof(T));

            //var item = node.Descendants(nodeName)?.Select(x => x.Value).ToString();
            //return (T)Convert.ChangeType(item, typeof(T));
        }
    }
}