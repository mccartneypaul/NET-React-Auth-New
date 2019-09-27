using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_React_Auth_New.Models
{
    public class Staff
    {
        public string StaffFirstName { get; set; }
        public string StaffLastName { get; set; }
        public string StaffEmail { get; set; }
        public string StaffRole { get; set; }
        public Guid StaffID { get; set; }
    }
}