namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cancelChanneling : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patient_Channel_Cancel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChannelDate = c.DateTime(nullable: false),
                        ChannelTime = c.DateTime(nullable: false),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoomNumber = c.Int(nullable: false),
                        ChannelNumber = c.Int(nullable: false),
                        Doctor_ID = c.Int(),
                        Patient_ID = c.Int(),
                        Patient_Contact = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.Doctor_ID)
                .ForeignKey("dbo.Patients", t => new { t.Patient_ID, t.Patient_Contact })
                .Index(t => t.Doctor_ID)
                .Index(t => new { t.Patient_ID, t.Patient_Contact });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient_Channel_Cancel", new[] { "Patient_ID", "Patient_Contact" }, "dbo.Patients");
            DropForeignKey("dbo.Patient_Channel_Cancel", "Doctor_ID", "dbo.Doctors");
            DropIndex("dbo.Patient_Channel_Cancel", new[] { "Patient_ID", "Patient_Contact" });
            DropIndex("dbo.Patient_Channel_Cancel", new[] { "Doctor_ID" });
            DropTable("dbo.Patient_Channel_Cancel");
        }
    }
}
