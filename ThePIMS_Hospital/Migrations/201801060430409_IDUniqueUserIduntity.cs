namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDUniqueUserIduntity : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", new[] { "ID", "email" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", new[] { "ID", "email" });
        }
    }
}
