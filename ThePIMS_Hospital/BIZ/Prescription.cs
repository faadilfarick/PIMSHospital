using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Prescription
    {
       
        public int ID { get; set; }
        public int TrackNo { get; set; }
        public string Deseas_Type{ get; set; }
        public string Description { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }

      
    }
}
