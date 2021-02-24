namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalKeyAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rental",
                c => new
                    {
                        RentalID = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RentalID)
                .ForeignKey("dbo.Customer", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Owner",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            AddColumn("dbo.Tool", "Owner_OwnerId", c => c.Int());
            CreateIndex("dbo.Tool", "Owner_OwnerId");
            AddForeignKey("dbo.Tool", "Owner_OwnerId", "dbo.Owner", "OwnerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tool", "Owner_OwnerId", "dbo.Owner");
            DropForeignKey("dbo.Rental", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Tool", new[] { "Owner_OwnerId" });
            DropIndex("dbo.Rental", new[] { "Customer_Id" });
            DropColumn("dbo.Tool", "Owner_OwnerId");
            DropTable("dbo.Owner");
            DropTable("dbo.Rental");
            DropTable("dbo.Customer");
        }
    }
}
