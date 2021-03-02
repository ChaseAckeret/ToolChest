namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRentalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rental", "ToolId", c => c.Int());
            AddColumn("dbo.Rental", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Rental", "ScheduledStartDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Rental", "ScheduledEndDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            CreateIndex("dbo.Rental", "ToolId");
            CreateIndex("dbo.Rental", "CustomerId");
            AddForeignKey("dbo.Rental", "CustomerId", "dbo.User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Rental", "ToolId", "dbo.Tool", "ToolID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rental", "ToolId", "dbo.Tool");
            DropForeignKey("dbo.Rental", "CustomerId", "dbo.User");
            DropIndex("dbo.Rental", new[] { "CustomerId" });
            DropIndex("dbo.Rental", new[] { "ToolId" });
            DropColumn("dbo.Rental", "ScheduledEndDate");
            DropColumn("dbo.Rental", "ScheduledStartDate");
            DropColumn("dbo.Rental", "CustomerId");
            DropColumn("dbo.Rental", "ToolId");
        }
    }
}
