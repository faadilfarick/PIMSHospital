namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prescriptionID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Prescriptions");
            AlterColumn("dbo.Prescriptions", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Prescriptions", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Prescriptions");
            AlterColumn("dbo.Prescriptions", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Prescriptions", "ID");
        }
    }
}
