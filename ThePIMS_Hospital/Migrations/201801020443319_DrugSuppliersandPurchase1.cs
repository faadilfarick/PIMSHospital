namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrugSuppliersandPurchase1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drug_Purchase", "Supplier");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drug_Purchase", "Supplier", c => c.String());
        }
    }
}
