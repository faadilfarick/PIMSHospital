namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patContcatUnique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Patients", "Contact", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Patients", new[] { "Contact" });
        }
    }
}
