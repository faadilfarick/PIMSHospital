namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientPK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patient_Channel", "Patient_ID", "dbo.Patients");
            DropIndex("dbo.Patient_Channel", new[] { "Patient_ID" });
            DropPrimaryKey("dbo.Patients");
            AddColumn("dbo.Patient_Channel", "Patient_Contact", c => c.Int());
            AlterColumn("dbo.Patients", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Patients", new[] { "ID", "Contact" });
            CreateIndex("dbo.Patient_Channel", new[] { "Patient_ID", "Patient_Contact" });
            AddForeignKey("dbo.Patient_Channel", new[] { "Patient_ID", "Patient_Contact" }, "dbo.Patients", new[] { "ID", "Contact" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient_Channel", new[] { "Patient_ID", "Patient_Contact" }, "dbo.Patients");
            DropIndex("dbo.Patient_Channel", new[] { "Patient_ID", "Patient_Contact" });
            DropPrimaryKey("dbo.Patients");
            AlterColumn("dbo.Patients", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Patient_Channel", "Patient_Contact");
            AddPrimaryKey("dbo.Patients", "ID");
            CreateIndex("dbo.Patient_Channel", "Patient_ID");
            AddForeignKey("dbo.Patient_Channel", "Patient_ID", "dbo.Patients", "ID");
        }
    }
}
