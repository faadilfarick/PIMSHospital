namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prescriptionDetailsTrack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescription_details", "TrackNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prescription_details", "TrackNo");
        }
    }
}
