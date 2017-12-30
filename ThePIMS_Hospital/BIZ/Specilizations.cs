using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Specilization
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }

        public virtual IEnumerable<Doctor> Doctor { get; set; }

    }
}
