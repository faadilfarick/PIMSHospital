namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQtyAviDrugInv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drug_Inventory", "availableQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drug_Inventory", "availableQuantity");
        }
    }
}
