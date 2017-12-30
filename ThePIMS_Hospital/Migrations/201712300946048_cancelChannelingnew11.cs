namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cancelChannelingnew11 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Patient_Channel_Cancel");
            AlterColumn("dbo.Patient_Channel_Cancel", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Patient_Channel_Cancel", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Patient_Channel_Cancel");
            AlterColumn("dbo.Patient_Channel_Cancel", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Patient_Channel_Cancel", "ID");
        }
    }
}
