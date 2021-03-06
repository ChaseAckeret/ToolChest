namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulltoolidinrentalbeforedelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rental", "CustomerId", "dbo.User");
            DropIndex("dbo.Rental", new[] { "CustomerId" });
            AlterColumn("dbo.Rental", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rental", "CustomerId");
            AddForeignKey("dbo.Rental", "CustomerId", "dbo.User", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rental", "CustomerId", "dbo.User");
            DropIndex("dbo.Rental", new[] { "CustomerId" });
            AlterColumn("dbo.Rental", "CustomerId", c => c.Int());
            CreateIndex("dbo.Rental", "CustomerId");
            AddForeignKey("dbo.Rental", "CustomerId", "dbo.User", "UserID");
        }
    }
}
