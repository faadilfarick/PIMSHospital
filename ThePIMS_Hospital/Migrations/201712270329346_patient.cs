namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contact = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        DOB = c.String(),
                        NIC = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Patient_Channel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChannelDate = c.String(),
                        ChannelTime = c.String(),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoomNumber = c.Int(nullable: false),
                        ChannelNumber = c.Int(nullable: false),
                        Patient_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Patients", t => t.Patient_ID)
                .Index(t => t.Patient_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient_Channel", "Patient_ID", "dbo.Patients");
            DropIndex("dbo.Patient_Channel", new[] { "Patient_ID" });
            DropTable("dbo.Patient_Channel");
            DropTable("dbo.Patients");
        }
    }
}
