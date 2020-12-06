using NavigationChallenge.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace NavigationChallenge.Controllers
{
    public class NavigatorController : Controller
    {
        // GET: Navigator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadOrderForm()
        {
            string baseNode = "Orders/Order/";
            Order formOrder = new Order();
            formOrder.AddressList = new List<Address>();
            formOrder.OrderItems = new List<LineItem>();

            string navChallenge = Request.Files[0].FileName;
            string serverPath = Server.MapPath("~/Orders/");
            Request.Files[0].SaveAs(serverPath + navChallenge);
            string orderPath = Path.Combine(serverPath, navChallenge);

            XDocument xDoc = XDocument.Load(orderPath);
            
            string nodePath = "Header/OrderHeader";
            formOrder.TradingPartnerId = OrderModel.GetNodeValue(xDoc, nodePath, "TradingPartnerId");
            formOrder.PurchaseOrderNumber = OrderModel.GetNodeValue(xDoc, nodePath, "PurchaseOrderNumber");
            formOrder.PurchaseOrderDate = Convert.ToDateTime(OrderModel.GetNodeValue(xDoc, nodePath, "PurchaseOrderDate"));
            formOrder.TotalAmount = decimal.Parse(OrderModel.GetNodeValue(xDoc, "Summary", "TotalAmount"));
            formOrder.TotalLineItemNumber = int.Parse(OrderModel.GetNodeValue(xDoc, "Summary", "TotalLineItemNumber"));

            nodePath = "Header/CarrierInformation";
            CarrierInformation carryInfo = new CarrierInformation();
            carryInfo.TransMethodCode = OrderModel.GetNodeValue(xDoc, nodePath, "CarrierTransMethodCode");
            carryInfo.AlphaCode = OrderModel.GetNodeValue(xDoc, nodePath, "CarrierAlphaCode");
            carryInfo.Routing = OrderModel.GetNodeValue(xDoc, nodePath, "CarrierRouting");
            carryInfo.DescriptionCode = OrderModel.GetNodeValue(xDoc, nodePath, "EquipmentDescriptionCode");
            formOrder.CarrierInfo = carryInfo;

            //XmlNodeList nodeList = doc.SelectNodes("Orders/Order/Header/Address");
            nodePath = "Header/Address";
            var nodeList = xDoc.XPathSelectElements($"{baseNode}{nodePath}");
            foreach (XElement node in nodeList)
            {
                formOrder.AddressList.Add(new Address()
                {
                    AddressTypeCode = OrderModel.GetNodeValue<string>(node, "AddressTypeCode"),
                    LocCodeQualifier = OrderModel.GetNodeValue<int>(node, "LocationCodeQualifier"),
                    LocationNumber = OrderModel.GetNodeValue<long>(node, "AddressLocationNumber"),
                    AddressName = OrderModel.GetNodeValue<string>(node, "AddressName"),
                    Address1 = OrderModel.GetNodeValue<string>(node, "Address1"),
                    Address2 = OrderModel.GetNodeValue<string>(node, "Address2"),
                    City = OrderModel.GetNodeValue<string>(node, "City"),
                    State = OrderModel.GetNodeValue<string>(node, "State"),
                    PostalCode = OrderModel.GetNodeValue<string>(node, "PostalCode"),
                    CountryCode = OrderModel.GetNodeValue<string>(node, "Country")
                });
            }
            
            nodePath = "LineItem/OrderLine";
            var itemNodeList = xDoc.XPathSelectElements($"{baseNode}{nodePath}");
            foreach (XElement node in itemNodeList)
            {
                formOrder.OrderItems.Add(new LineItem()
                {
                    LineSequenceNumberId = OrderModel.GetNodeValue<int>(node, "LineSequenceNumber"),
                    BuyerPartNumber = OrderModel.GetNodeValue<string>(node, "BuyerPartNumber"),
                    VendorPartNumber = OrderModel.GetNodeValue<string>(node, "VendorPartNumber"),
                    ConsumerPackageCode = OrderModel.GetNodeValue<string>(node, "ConsumerPackageCode"),
                    OrderQty = OrderModel.GetNodeValue<int>(node, "OrderQty"),
                    OrderQtyUOM = OrderModel.GetNodeValue<string>(node, "OrderQtyUOM"),
                    PurchasePrice = OrderModel.GetNodeValue<decimal>(node, "PurchasePrice")
                });
            }

            return View(formOrder);
        }
    }
}