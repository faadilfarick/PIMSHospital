namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drugInventryandCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drug_Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Drug_Inventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Unit_Selling_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reorder_Level = c.Int(nullable: false),
                        Unit_Buying_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Issued_Quantity = c.Int(nullable: false),
                        Drug_Type = c.String(),
                        Shelf = c.String(),
                        Drug_Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug_Category", t => t.Drug_Category_ID)
                .Index(t => t.Drug_Category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drug_Inventory", "Drug_Category_ID", "dbo.Drug_Category");
            DropIndex("dbo.Drug_Inventory", new[] { "Drug_Category_ID" });
            DropTable("dbo.Drug_Inventory");
            DropTable("dbo.Drug_Category");
        }
    }
}
