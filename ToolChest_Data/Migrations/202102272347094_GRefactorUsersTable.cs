namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GRefactorUsersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerRating", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Rental", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.OwnerRating", "Owner_UserId", "dbo.Owner");
            DropForeignKey("dbo.Owner", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Tool", "UserID", "dbo.Owner");
            DropForeignKey("dbo.Rental", "ToolId", "dbo.Tool");
            DropIndex("dbo.CustomerRating", new[] { "CustomerId" });
            DropIndex("dbo.Rental", new[] { "ToolId" });
            DropIndex("dbo.Rental", new[] { "CustomerId" });
            DropIndex("dbo.Tool", new[] { "UserID" });
            DropIndex("dbo.Owner", new[] { "UserId" });
            DropIndex("dbo.OwnerRating", new[] { "Owner_UserId" });
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
            
            AddColumn("dbo.CustomerRating", "CustomerUserID", c => c.Int(nullable: false));
            AddColumn("dbo.OwnerRating", "OwnerUserID", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerRating", "CustomerUserID");
            CreateIndex("dbo.OwnerRating", "OwnerUserID");
            CreateIndex("dbo.Tool", "OwnerID");
            AddForeignKey("dbo.OwnerRating", "OwnerUserID", "dbo.User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Tool", "OwnerID", "dbo.User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.CustomerRating", "CustomerUserID", "dbo.User", "UserID", cascadeDelete: true);
            DropColumn("dbo.CustomerRating", "CustomerId");
            DropColumn("dbo.Rental", "ToolId");
            DropColumn("dbo.Rental", "CustomerId");
            DropColumn("dbo.Rental", "ScheduledStartDate");
            DropColumn("dbo.Rental", "ScheduledEndDate");
            DropColumn("dbo.Tool", "UserID");
            DropColumn("dbo.OwnerRating", "Owner_UserId");
            DropColumn("dbo.ApplicationUser", "FName");
            DropColumn("dbo.ApplicationUser", "LName");
            DropColumn("dbo.ApplicationUser", "StreetAddress");
            DropColumn("dbo.ApplicationUser", "City");
            DropColumn("dbo.ApplicationUser", "State");
            DropColumn("dbo.ApplicationUser", "Zip");
            DropTable("dbo.Customer");
            DropTable("dbo.Owner");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Owner",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        OwnerId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.UserId);
            
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
            
            AddColumn("dbo.ApplicationUser", "Zip", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "State", c => c.String());
            AddColumn("dbo.ApplicationUser", "City", c => c.String());
            AddColumn("dbo.ApplicationUser", "StreetAddress", c => c.String());
            AddColumn("dbo.ApplicationUser", "LName", c => c.String());
            AddColumn("dbo.ApplicationUser", "FName", c => c.String());
            AddColumn("dbo.OwnerRating", "Owner_UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Tool", "UserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Rental", "ScheduledEndDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Rental", "ScheduledStartDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Rental", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Rental", "ToolId", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerRating", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CustomerRating", "CustomerUserID", "dbo.User");
            DropForeignKey("dbo.Tool", "OwnerID", "dbo.User");
            DropForeignKey("dbo.OwnerRating", "OwnerUserID", "dbo.User");
            DropIndex("dbo.Tool", new[] { "OwnerID" });
            DropIndex("dbo.OwnerRating", new[] { "OwnerUserID" });
            DropIndex("dbo.CustomerRating", new[] { "CustomerUserID" });
            DropColumn("dbo.OwnerRating", "OwnerUserID");
            DropColumn("dbo.CustomerRating", "CustomerUserID");
            DropTable("dbo.User");
            CreateIndex("dbo.OwnerRating", "Owner_UserId");
            CreateIndex("dbo.Owner", "UserId");
            CreateIndex("dbo.Tool", "UserID");
            CreateIndex("dbo.Rental", "CustomerId");
            CreateIndex("dbo.Rental", "ToolId");
            CreateIndex("dbo.CustomerRating", "CustomerId");
            AddForeignKey("dbo.Rental", "ToolId", "dbo.Tool", "ToolID", cascadeDelete: true);
            AddForeignKey("dbo.Tool", "UserID", "dbo.Owner", "UserId");
            AddForeignKey("dbo.Owner", "UserId", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.OwnerRating", "Owner_UserId", "dbo.Owner", "UserId");
            AddForeignKey("dbo.Rental", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerRating", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
        }
    }
}
