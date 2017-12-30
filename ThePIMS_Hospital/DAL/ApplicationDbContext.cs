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
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Drug_Category> Drug_Category { get; set; }
        public DbSet<Drug_Inventory> Drug_Inventory { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Patient_Channel> PatientChannel { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Prescription_details> Prescription_details { get; set; }
        public DbSet<Specilization> Specilization { get; set; }
    }
}
