using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavigationChallenge.Models
{
    public class LineItem
    {
        public int LineSequenceNumberId { get; set; }
        public string BuyerPartNumber { get; set; }
        public string VendorPartNumber { get; set; }
        public string ConsumerPackageCode { get; set; }
        public int OrderQty { get; set; }
        public string OrderQtyUOM { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}