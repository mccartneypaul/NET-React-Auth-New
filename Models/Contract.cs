using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_React_Auth_New.Models
{
    public class Contract
    {
        public string ContractDescription { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractEndDate { get; set; }
        public Guid ContractCustomerID { get; set; }
        public Guid ContractID { get; set; }
    }
}