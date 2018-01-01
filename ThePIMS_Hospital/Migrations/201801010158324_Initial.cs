namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Qualification = c.String(),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Contact = c.Int(nullable: false),
                        Specilization_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Specilizations", t => t.Specilization_ID)
                .Index(t => t.Specilization_ID);
            
            CreateTable(
                "dbo.Specilizations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Drug_Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Drug_Inventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Unit_Selling_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reorder_Level = c.Int(nullable: false),
                        Unit_Buying_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Issued_Quantity = c.Int(nullable: false),
                        Drug_Type = c.String(),
                        Shelf = c.String(),
                        availableQuantity = c.Int(nullable: false),
                        Drug_Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug_Category", t => t.Drug_Category_ID)
                .Index(t => t.Drug_Category_ID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contact = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        DOB = c.String(),
                        NIC = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Contact })
                .Index(t => t.Contact, unique: true);
            
            CreateTable(
                "dbo.Patient_Channel_Cancel",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ChannelDate = c.DateTime(nullable: false),
                        ChannelTime = c.DateTime(nullable: false),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoomNumber = c.Int(nullable: false),
                        ChannelNumber = c.Int(nullable: false),
                        Doctor_ID = c.Int(),
                        Patient_ID = c.Int(),
                        Patient_Contact = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.Doctor_ID)
                .ForeignKey("dbo.Patients", t => new { t.Patient_ID, t.Patient_Contact })
                .Index(t => t.Doctor_ID)
                .Index(t => new { t.Patient_ID, t.Patient_Contact });
            
            CreateTable(
                "dbo.Patient_Channel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChannelDate = c.DateTime(nullable: false),
                        ChannelTime = c.DateTime(nullable: false),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoomNumber = c.Int(nullable: false),
                        ChannelNumber = c.Int(nullable: false),
                        Doctor_ID = c.Int(),
                        Patient_ID = c.Int(),
                        Patient_Contact = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.Doctor_ID)
                .ForeignKey("dbo.Patients", t => new { t.Patient_ID, t.Patient_Contact })
                .Index(t => t.Doctor_ID)
                .Index(t => new { t.Patient_ID, t.Patient_Contact });
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrackNo = c.Int(nullable: false),
                        Deseas_Type = c.String(),
                        Description = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Doctor_ID = c.Int(),
                        Patient_ID = c.Int(),
                        Patient_Contact = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.Doctor_ID)
                .ForeignKey("dbo.Patients", t => new { t.Patient_ID, t.Patient_Contact })
                .Index(t => t.Doctor_ID)
                .Index(t => new { t.Patient_ID, t.Patient_Contact });
            
            CreateTable(
                "dbo.Prescription_details",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        discription = c.String(),
                        Quantity = c.Int(nullable: false),
                        TrackNo = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GetDrug_Inventory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug_Inventory", t => t.GetDrug_Inventory_ID)
                .Index(t => t.GetDrug_Inventory_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        contact = c.Int(nullable: false),
                        email = c.String(),
                        nic = c.String(),
                        dob = c.DateTime(nullable: false),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescription_details", "GetDrug_Inventory_ID", "dbo.Drug_Inventory");
            DropForeignKey("dbo.Prescriptions", new[] { "Patient_ID", "Patient_Contact" }, "dbo.Patients");
            DropForeignKey("dbo.Prescriptions", "Doctor_ID", "dbo.Doctors");
            DropForeignKey("dbo.Patient_Channel", new[] { "Patient_ID", "Patient_Contact" }, "dbo.Patients");
            DropForeignKey("dbo.Patient_Channel", "Doctor_ID", "dbo.Doctors");
            DropForeignKey("dbo.Patient_Channel_Cancel", new[] { "Patient_ID", "Patient_Contact" }, "dbo.Patients");
            DropForeignKey("dbo.Patient_Channel_Cancel", "Doctor_ID", "dbo.Doctors");
            DropForeignKey("dbo.Drug_Inventory", "Drug_Category_ID", "dbo.Drug_Category");
            DropForeignKey("dbo.Doctors", "Specilization_ID", "dbo.Specilizations");
            DropIndex("dbo.Prescription_details", new[] { "GetDrug_Inventory_ID" });
            DropIndex("dbo.Prescriptions", new[] { "Patient_ID", "Patient_Contact" });
            DropIndex("dbo.Prescriptions", new[] { "Doctor_ID" });
            DropIndex("dbo.Patient_Channel", new[] { "Patient_ID", "Patient_Contact" });
            DropIndex("dbo.Patient_Channel", new[] { "Doctor_ID" });
            DropIndex("dbo.Patient_Channel_Cancel", new[] { "Patient_ID", "Patient_Contact" });
            DropIndex("dbo.Patient_Channel_Cancel", new[] { "Doctor_ID" });
            DropIndex("dbo.Patients", new[] { "Contact" });
            DropIndex("dbo.Drug_Inventory", new[] { "Drug_Category_ID" });
            DropIndex("dbo.Doctors", new[] { "Specilization_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Prescription_details");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Patient_Channel");
            DropTable("dbo.Patient_Channel_Cancel");
            DropTable("dbo.Patients");
            DropTable("dbo.Drug_Inventory");
            DropTable("dbo.Drug_Category");
            DropTable("dbo.Specilizations");
            DropTable("dbo.Doctors");
        }
    }
}
