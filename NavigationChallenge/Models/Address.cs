using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavigationChallenge.Models
{
    public class Address
    {
        public string AddressTypeCode { get; set; }
        public int LocCodeQualifier { get; set; }
        public long LocationNumber { get; set; }
        public string AddressName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
    }
}