namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerRating",
                c => new
                    {
                        CustomerRatingId = c.Int(nullable: false, identity: true),
                        CustomerUserID = c.Int(nullable: false),
                        Timeliness = c.Int(nullable: false),
                        Care = c.Int(nullable: false),
                        Ease = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerRatingId)
                .ForeignKey("dbo.User", t => t.CustomerUserID, cascadeDelete: true)
                .Index(t => t.CustomerUserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.OwnerRating",
                c => new
                    {
                        OwnerRatingId = c.Int(nullable: false, identity: true),
                        FKOwnerID = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Availability = c.Int(nullable: false),
                        Timeliness = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OwnerRatingId)
                .ForeignKey("dbo.User", t => t.FKOwnerID, cascadeDelete: true)
                .Index(t => t.FKOwnerID);
            
            CreateTable(
                "dbo.Rental",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        ToolId = c.Int(),
                        CustomerId = c.Int(nullable: false),
                        RecieptId = c.Int(nullable: false),
                        ScheduledStartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ScheduledEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.RentalId)
                .ForeignKey("dbo.User", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Tool", t => t.ToolId)
                .Index(t => t.ToolId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Receipt",
                c => new
                    {
                        ReceiptId = c.Int(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        ActualStartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ActualEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ReceiptId)
                .ForeignKey("dbo.Rental", t => t.ReceiptId)
                .Index(t => t.ReceiptId);
            
            CreateTable(
                "dbo.Tool",
                c => new
                    {
                        ToolID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Int(nullable: false),
                        HourlyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DailyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToolCondition = c.Int(nullable: false),
                        ToolCatalogItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ToolID)
                .ForeignKey("dbo.User", t => t.OwnerID, cascadeDelete: true)
                .ForeignKey("dbo.ToolCatalogItem", t => t.ToolCatalogItemID, cascadeDelete: true)
                .Index(t => t.OwnerID)
                .Index(t => t.ToolCatalogItemID);
            
            CreateTable(
                "dbo.ToolRating",
                c => new
                    {
                        ToolRatingID = c.Int(nullable: false, identity: true),
                        FKToolID = c.Int(nullable: false),
                        Condition = c.Double(nullable: false),
                        Usability = c.Double(nullable: false),
                        Accuracy = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ToolRatingID)
                .ForeignKey("dbo.Tool", t => t.FKToolID, cascadeDelete: true)
                .Index(t => t.FKToolID);
            
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
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.CustomerRating", "CustomerUserID", "dbo.User");
            DropForeignKey("dbo.Rental", "ToolId", "dbo.Tool");
            DropForeignKey("dbo.Tool", "ToolCatalogItemID", "dbo.ToolCatalogItem");
            DropForeignKey("dbo.ToolRating", "FKToolID", "dbo.Tool");
            DropForeignKey("dbo.Tool", "OwnerID", "dbo.User");
            DropForeignKey("dbo.Receipt", "ReceiptId", "dbo.Rental");
            DropForeignKey("dbo.Rental", "CustomerId", "dbo.User");
            DropForeignKey("dbo.OwnerRating", "FKOwnerID", "dbo.User");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ToolRating", new[] { "FKToolID" });
            DropIndex("dbo.Tool", new[] { "ToolCatalogItemID" });
            DropIndex("dbo.Tool", new[] { "OwnerID" });
            DropIndex("dbo.Receipt", new[] { "ReceiptId" });
            DropIndex("dbo.Rental", new[] { "CustomerId" });
            DropIndex("dbo.Rental", new[] { "ToolId" });
            DropIndex("dbo.OwnerRating", new[] { "FKOwnerID" });
            DropIndex("dbo.CustomerRating", new[] { "CustomerUserID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.ToolCatalogItem");
            DropTable("dbo.ToolRating");
            DropTable("dbo.Tool");
            DropTable("dbo.Receipt");
            DropTable("dbo.Rental");
            DropTable("dbo.OwnerRating");
            DropTable("dbo.User");
            DropTable("dbo.CustomerRating");
        }
    }
}
