using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Drug_Purchase
    {
        public int ID { get; set; }
        
        public DateTime Date { get; set; }

        public int Quantity { get; set; }

        public virtual Drug_Inventory Drug_Inventry { get; set; }

        public virtual Drug_Supplier Drug_Supplier { get; set; }
    }
}
