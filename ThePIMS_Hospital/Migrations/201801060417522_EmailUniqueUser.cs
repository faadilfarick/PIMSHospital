namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailUniqueUser : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "email");
            CreateIndex("dbo.Users", "email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "email" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "email", c => c.String());
            AlterColumn("dbo.Users", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "ID");
        }
    }
}
