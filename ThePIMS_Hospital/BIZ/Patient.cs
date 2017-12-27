using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class Patient
    {
        [Key, Column(Order = 0)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Key, Column(Order = 1)]
        [Index(IsUnique = true)]
        public int Contact { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string NIC { get; set; }

        public virtual IEnumerable<Patient_Channel> PatientChannel { get; set; }
    }
}
