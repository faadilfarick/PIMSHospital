using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Patient_Channel
    {
        public int ID { get; set; }
        public DateTime ChannelDate { get; set; }
        public DateTime ChannelTime { get; set; }
        public decimal Fee { get; set; }
        public int RoomNumber { get; set; }
        public int ChannelNumber { get; set; }

        public virtual Patient Patient { get; set; }       
        public virtual Doctor Doctor { get; set; }
    }
}
