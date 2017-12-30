using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Drug_Inventory
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Item_Category { get; set; }
        public decimal Unit_Selling_Price { get; set; }
        public int Reorder_Level { get; set; }
        public decimal Unit_Buying_Price { get; set; }
        public int Issued_Quantity { get; set; }
        public string Drug_Type { get; set; }
        public string Shelf { get; set; }
        public string Category { get; set; }

    }
}
