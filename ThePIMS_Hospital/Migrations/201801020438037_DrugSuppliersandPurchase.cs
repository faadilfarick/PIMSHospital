namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrugSuppliersandPurchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drug_Purchase",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Supplier = c.String(),
                        Date = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Drug_Inventry_ID = c.Int(),
                        Drug_Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug_Inventory", t => t.Drug_Inventry_ID)
                .ForeignKey("dbo.Drug_Supplier", t => t.Drug_Supplier_ID)
                .Index(t => t.Drug_Inventry_ID)
                .Index(t => t.Drug_Supplier_ID);
            
            CreateTable(
                "dbo.Drug_Supplier",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contact = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drug_Purchase", "Drug_Supplier_ID", "dbo.Drug_Supplier");
            DropForeignKey("dbo.Drug_Purchase", "Drug_Inventry_ID", "dbo.Drug_Inventory");
            DropIndex("dbo.Drug_Purchase", new[] { "Drug_Supplier_ID" });
            DropIndex("dbo.Drug_Purchase", new[] { "Drug_Inventry_ID" });
            DropTable("dbo.Drug_Supplier");
            DropTable("dbo.Drug_Purchase");
        }
    }
}
