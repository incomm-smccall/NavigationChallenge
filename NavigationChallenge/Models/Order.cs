using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavigationChallenge.Models
{
    public class Order
    {
        public string TradingPartnerId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public DateTime PurchaseOrderDate { get; set; }

        public IList<Address> AddressList { get; set; }
        public CarrierInformation CarrierInfo { get; set; }
        public IList<LineItem> OrderItems { get; set; }

        public decimal TotalAmount { get; set; }
        public int TotalLineItemNumber { get; set; }
    }
}