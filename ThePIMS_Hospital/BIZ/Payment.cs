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
        public int TrackNo { get; set; }
        public int Amount { get; set; }
        public DateTime dateTime { get; set; }
        public string PaymentType { get; set; }
        public int Contact { get; set; }

        public virtual Prescription Prescription { get; set; }

    }
}
