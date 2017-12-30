namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatatypechangeChennel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patient_Channel", "ChannelDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Patient_Channel", "ChannelTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patient_Channel", "ChannelTime", c => c.String());
            AlterColumn("dbo.Patient_Channel", "ChannelDate", c => c.String());
        }
    }
}
