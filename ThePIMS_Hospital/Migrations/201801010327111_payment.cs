namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class payment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrackNo = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        PaymentType = c.String(),
                        Contact = c.Int(nullable: false),
                        Prescription_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prescriptions", t => t.Prescription_ID)
                .Index(t => t.Prescription_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Prescription_ID", "dbo.Prescriptions");
            DropIndex("dbo.Payments", new[] { "Prescription_ID" });
            DropTable("dbo.Payments");
        }
    }
}
