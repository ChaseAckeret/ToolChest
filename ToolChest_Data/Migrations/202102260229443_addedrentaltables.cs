namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrentaltables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rental", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Rental", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Rental", name: "Customer_Id", newName: "CustomerId");
            AddColumn("dbo.Rental", "ToolId", c => c.Int(nullable: false));
            AddColumn("dbo.Rental", "ScheduledStartDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Rental", "ScheduledEndDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Rental", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rental", "ToolId");
            CreateIndex("dbo.Rental", "CustomerId");
            AddForeignKey("dbo.Rental", "ToolId", "dbo.Tool", "ToolID", cascadeDelete: true);
            AddForeignKey("dbo.Rental", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rental", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Rental", "ToolId", "dbo.Tool");
            DropIndex("dbo.Rental", new[] { "CustomerId" });
            DropIndex("dbo.Rental", new[] { "ToolId" });
            AlterColumn("dbo.Rental", "CustomerId", c => c.Int());
            DropColumn("dbo.Rental", "ScheduledEndDate");
            DropColumn("dbo.Rental", "ScheduledStartDate");
            DropColumn("dbo.Rental", "ToolId");
            RenameColumn(table: "dbo.Rental", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Rental", "Customer_Id");
            AddForeignKey("dbo.Rental", "Customer_Id", "dbo.Customer", "Id");
        }
    }
}
