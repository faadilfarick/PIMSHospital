namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDUniqueUser : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AddPrimaryKey("dbo.Users", new[] { "ID", "email" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AddPrimaryKey("dbo.Users", "email");
        }
    }
}
