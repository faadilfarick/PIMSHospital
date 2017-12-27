namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocsUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patient_Channel", "ID", "dbo.Doctors");
            DropIndex("dbo.Patient_Channel", new[] { "ID" });
            DropPrimaryKey("dbo.Patient_Channel");
            AddColumn("dbo.Patient_Channel", "Doctor_ID", c => c.Int());
            AlterColumn("dbo.Patient_Channel", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Patient_Channel", "ID");
            CreateIndex("dbo.Patient_Channel", "Doctor_ID");
            AddForeignKey("dbo.Patient_Channel", "Doctor_ID", "dbo.Doctors", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient_Channel", "Doctor_ID", "dbo.Doctors");
            DropIndex("dbo.Patient_Channel", new[] { "Doctor_ID" });
            DropPrimaryKey("dbo.Patient_Channel");
            AlterColumn("dbo.Patient_Channel", "ID", c => c.Int(nullable: false));
            DropColumn("dbo.Patient_Channel", "Doctor_ID");
            AddPrimaryKey("dbo.Patient_Channel", "ID");
            CreateIndex("dbo.Patient_Channel", "ID");
            AddForeignKey("dbo.Patient_Channel", "ID", "dbo.Doctors", "ID");
        }
    }
}
