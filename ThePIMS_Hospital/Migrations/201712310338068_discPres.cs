namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discPres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescriptions", "Prescription_Details_ID", "dbo.Prescription_details");
            DropIndex("dbo.Prescriptions", new[] { "Prescription_Details_ID" });
            AddColumn("dbo.Prescription_details", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Prescriptions", "Prescription_Details_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prescriptions", "Prescription_Details_ID", c => c.Int());
            DropColumn("dbo.Prescription_details", "Price");
            CreateIndex("dbo.Prescriptions", "Prescription_Details_ID");
            AddForeignKey("dbo.Prescriptions", "Prescription_Details_ID", "dbo.Prescription_details", "ID");
        }
    }
}
