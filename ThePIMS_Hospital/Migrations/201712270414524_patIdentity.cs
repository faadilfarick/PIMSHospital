namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patient_Channel", new[] { "Patient_ID", "Patient_Contact" }, "dbo.Patients");
            DropPrimaryKey("dbo.Patients");
            AlterColumn("dbo.Patients", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Patients", new[] { "ID", "Contact" });
            AddForeignKey("dbo.Patient_Channel", new[] { "Patient_ID", "Patient_Contact" }, "dbo.Patients", new[] { "ID", "Contact" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient_Channel", new[] { "Patient_ID", "Patient_Contact" }, "dbo.Patients");
            DropPrimaryKey("dbo.Patients");
            AlterColumn("dbo.Patients", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Patients", new[] { "ID", "Contact" });
            AddForeignKey("dbo.Patient_Channel", new[] { "Patient_ID", "Patient_Contact" }, "dbo.Patients", new[] { "ID", "Contact" });
        }
    }
}
