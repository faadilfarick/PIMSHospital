using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Payment
    {
        public int ID { get; set; }
        public int Prescription_ID { get; set; }
        public int Amount { get; set; }
        public String Date { get; set; }
        public int Customer_Contact { get; set; }
        public string Payment_Type { get; set; }

        public virtual Prescription Prescription { get; set; }
        public virtual Patient Patient { get; set; } //This might include patient and maybe supplier
    }
}
