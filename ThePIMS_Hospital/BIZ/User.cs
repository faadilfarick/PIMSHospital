using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int contact { get; set; }
        public string email { get; set; }
        public string nic { get; set; }
        public DateTime dob { get; set; }
        public string role { get; set; }
        public string Password { get; set; }
    }
}
