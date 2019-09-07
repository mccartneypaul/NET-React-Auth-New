using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_React_Auth_New.Models
{
    public class Prospect
    {
        public string ProspectDescription { get; set; }
        public string ProspectRcvdDate { get; set; }
        public string ProspectLastUpdateDate { get; set; }
        public string ProspectLastUpdateStaff { get; set; }
        public Guid ProspectID { get; set; }
    }
}