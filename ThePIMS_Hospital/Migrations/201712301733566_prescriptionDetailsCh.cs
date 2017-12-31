namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prescriptionDetailsCh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescription_details", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prescription_details", "Name");
        }
    }
}
