using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Prescription_details
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public string discription { get; set; }
        public int Quantity { get; set; }
        public int TrackNo { get; set; }
        public decimal Price { get; set; }

        public virtual Drug_Inventory GetDrug_Inventory { get; set; }

    }
}
