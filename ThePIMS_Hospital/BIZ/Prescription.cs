using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Prescription
    {
        public int ID { get; set; }
        public string Deseas_Type{ get; set; }
        public string Description { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Prescription_details Prescription_Details { get; set; }
    }
}
