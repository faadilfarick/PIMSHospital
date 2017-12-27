namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class docContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Contact", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Contact");
        }
    }
}
