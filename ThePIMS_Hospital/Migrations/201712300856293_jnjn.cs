namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jnjn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescription_details", "Prescription_ID", "dbo.Prescriptions");
            DropIndex("dbo.Prescriptions", new[] { "Doctor_ID1" });
            DropIndex("dbo.Prescriptions", new[] { "Patient_ID1", "Patient_Contact" });
            DropIndex("dbo.Prescription_details", new[] { "Prescription_ID" });
            DropColumn("dbo.Prescriptions", "Doctor_ID");
            DropColumn("dbo.Prescriptions", "Patient_ID");
            RenameColumn(table: "dbo.Prescriptions", name: "Doctor_ID1", newName: "Doctor_ID");
            RenameColumn(table: "dbo.Prescriptions", name: "Patient_ID1", newName: "Patient_ID");
            AddColumn("dbo.Prescriptions", "Prescription_Details_ID", c => c.Int());
            AlterColumn("dbo.Prescriptions", "Patient_ID", c => c.Int());
            AlterColumn("dbo.Prescriptions", "Doctor_ID", c => c.Int());
            CreateIndex("dbo.Prescriptions", "Doctor_ID");
            CreateIndex("dbo.Prescriptions", new[] { "Patient_ID", "Patient_Contact" });
            CreateIndex("dbo.Prescriptions", "Prescription_Details_ID");
            AddForeignKey("dbo.Prescriptions", "Prescription_Details_ID", "dbo.Prescription_details", "ID");
            DropColumn("dbo.Prescriptions", "Date");
            DropColumn("dbo.Prescription_details", "Prescription_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prescription_details", "Prescription_ID", c => c.Int());
            AddColumn("dbo.Prescriptions", "Date", c => c.String());
            DropForeignKey("dbo.Prescriptions", "Prescription_Details_ID", "dbo.Prescription_details");
            DropIndex("dbo.Prescriptions", new[] { "Prescription_Details_ID" });
            DropIndex("dbo.Prescriptions", new[] { "Patient_ID", "Patient_Contact" });
            DropIndex("dbo.Prescriptions", new[] { "Doctor_ID" });
            AlterColumn("dbo.Prescriptions", "Doctor_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Prescriptions", "Patient_ID", c => c.Int(nullable: false));
            DropColumn("dbo.Prescriptions", "Prescription_Details_ID");
            RenameColumn(table: "dbo.Prescriptions", name: "Patient_ID", newName: "Patient_ID1");
            RenameColumn(table: "dbo.Prescriptions", name: "Doctor_ID", newName: "Doctor_ID1");
            AddColumn("dbo.Prescriptions", "Patient_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Prescriptions", "Doctor_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Prescription_details", "Prescription_ID");
            CreateIndex("dbo.Prescriptions", new[] { "Patient_ID1", "Patient_Contact" });
            CreateIndex("dbo.Prescriptions", "Doctor_ID1");
            AddForeignKey("dbo.Prescription_details", "Prescription_ID", "dbo.Prescriptions", "ID");
        }
    }
}
