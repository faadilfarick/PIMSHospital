namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Docs : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Patient_Channel");
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Specialization = c.String(),
                        Qualification = c.String(),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Patient_Channel", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Patient_Channel", "ID");
            CreateIndex("dbo.Patient_Channel", "ID");
            AddForeignKey("dbo.Patient_Channel", "ID", "dbo.Doctors", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient_Channel", "ID", "dbo.Doctors");
            DropIndex("dbo.Patient_Channel", new[] { "ID" });
            DropPrimaryKey("dbo.Patient_Channel");
            AlterColumn("dbo.Patient_Channel", "ID", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Doctors");
            AddPrimaryKey("dbo.Patient_Channel", "ID");
        }
    }
}
