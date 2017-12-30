namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnameInventry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drug_Inventory", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drug_Inventory", "Name");
        }
    }
}
