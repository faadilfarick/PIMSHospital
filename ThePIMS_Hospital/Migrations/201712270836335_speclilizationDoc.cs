namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class speclilizationDoc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Specilization_ID", c => c.Int());
            CreateIndex("dbo.Doctors", "Specilization_ID");
            AddForeignKey("dbo.Doctors", "Specilization_ID", "dbo.Specilizations", "ID");
            DropColumn("dbo.Doctors", "Specialization");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Specialization", c => c.String());
            DropForeignKey("dbo.Doctors", "Specilization_ID", "dbo.Specilizations");
            DropIndex("dbo.Doctors", new[] { "Specilization_ID" });
            DropColumn("dbo.Doctors", "Specilization_ID");
        }
    }
}
