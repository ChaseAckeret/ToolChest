namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtoolentities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToolCatalogItem",
                c => new
                    {
                        ToolCatalogItemID = c.Int(nullable: false, identity: true),
                        Catagory = c.Int(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        LongDescription = c.String(),
                        Brand = c.String(),
                        PowerSource = c.String(),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.ToolCatalogItemID);
            
            CreateTable(
                "dbo.Tool",
                c => new
                    {
                        ToolID = c.Int(nullable: false, identity: true),
                        HourlyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DailyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToolCondition = c.Int(nullable: false),
                        ToolCatalogItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ToolID)
                .ForeignKey("dbo.ToolCatalogItem", t => t.ToolCatalogItemID, cascadeDelete: true)
                .Index(t => t.ToolCatalogItemID);
            
            CreateTable(
                "dbo.ToolRating",
                c => new
                    {
                        ToolRatingID = c.Int(nullable: false, identity: true),
                        ToolID = c.Int(nullable: false),
                        Condition = c.Double(nullable: false),
                        Usability = c.Double(nullable: false),
                        Accuracy = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ToolRatingID)
                .ForeignKey("dbo.Tool", t => t.ToolID, cascadeDelete: true)
                .Index(t => t.ToolID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tool", "ToolCatalogItemID", "dbo.ToolCatalogItem");
            DropForeignKey("dbo.ToolRating", "ToolID", "dbo.Tool");
            DropIndex("dbo.ToolRating", new[] { "ToolID" });
            DropIndex("dbo.Tool", new[] { "ToolCatalogItemID" });
            DropTable("dbo.ToolRating");
            DropTable("dbo.Tool");
            DropTable("dbo.ToolCatalogItem");
        }
    }
}
