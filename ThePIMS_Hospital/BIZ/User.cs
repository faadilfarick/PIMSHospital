using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePIMS_Hospital.BIZ
{
    class User
    {

        [Key, Column(Order = 0)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int contact { get; set; }
        [Index(IsUnique = true)]
        [Key, Column(Order = 4)]
        public string email { get; set; }
        public string nic { get; set; }
        public DateTime dob { get; set; }
        public string role { get; set; }
        public string Password { get; set; }
    }
}
