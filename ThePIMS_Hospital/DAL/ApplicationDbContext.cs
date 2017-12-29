using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePIMS_Hospital.BIZ;

namespace ThePIMS_Hospital.DAL
{
    class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext():base("name=DefaultConnection")
        {

        }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Patient_Channel> PatientChannel { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Specilization> Specilization { get; set; }

    }
}
