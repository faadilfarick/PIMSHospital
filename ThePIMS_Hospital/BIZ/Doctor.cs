using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Doctor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public string Qualification { get; set; }
        public decimal Fee { get; set; }
        public int Contact { get; set; }
        
        public virtual Specilization Specilization { get; set; }



    }
}
