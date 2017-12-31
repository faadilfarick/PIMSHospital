namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discPres1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prescriptions", "DateTime");
        }
    }
}
