using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Drug_Category
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public string Discription { get; set; }

        public virtual IEnumerable<Drug_Inventory> Drug_Inventory { get; set; }
    }
}
