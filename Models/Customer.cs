using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_React_Auth_New.Models
{
    public class Customer
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerCompanyName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerFirstStreetAddress { get; set; }
        public string CustomerScndStreetAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerZipCode { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerWebSite { get; set; }
        public Guid CustomerID { get; set; }
    }
}