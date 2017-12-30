namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prescriptionAndDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Patient_ID = c.Int(nullable: false),
                        Doctor_ID = c.Int(nullable: false),
                        Date = c.String(),
                        Deseas_Type = c.String(),
                        Description = c.String(),
                        Doctor_ID1 = c.Int(),
                        Patient_ID1 = c.Int(),
                        Patient_Contact = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.Doctor_ID1)
                .ForeignKey("dbo.Patients", t => new { t.Patient_ID1, t.Patient_Contact })
                .Index(t => t.Doctor_ID1)
                .Index(t => new { t.Patient_ID1, t.Patient_Contact });
            
            CreateTable(
                "dbo.Prescription_details",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        discription = c.String(),
                        Quantity = c.Int(nullable: false),
                        GetDrug_Inventory_ID = c.Int(),
                        Prescription_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug_Inventory", t => t.GetDrug_Inventory_ID)
                .ForeignKey("dbo.Prescriptions", t => t.Prescription_ID)
                .Index(t => t.GetDrug_Inventory_ID)
                .Index(t => t.Prescription_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescription_details", "Prescription_ID", "dbo.Prescriptions");
            DropForeignKey("dbo.Prescription_details", "GetDrug_Inventory_ID", "dbo.Drug_Inventory");
            DropForeignKey("dbo.Prescriptions", new[] { "Patient_ID1", "Patient_Contact" }, "dbo.Patients");
            DropForeignKey("dbo.Prescriptions", "Doctor_ID1", "dbo.Doctors");
            DropIndex("dbo.Prescription_details", new[] { "Prescription_ID" });
            DropIndex("dbo.Prescription_details", new[] { "GetDrug_Inventory_ID" });
            DropIndex("dbo.Prescriptions", new[] { "Patient_ID1", "Patient_Contact" });
            DropIndex("dbo.Prescriptions", new[] { "Doctor_ID1" });
            DropTable("dbo.Prescription_details");
            DropTable("dbo.Prescriptions");
        }
    }
}
