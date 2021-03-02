namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GUIDkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tool", "OwnerID", "dbo.Owner");
            DropIndex("dbo.Tool", new[] { "OwnerID" });
            AddColumn("dbo.Tool", "UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tool", "OwnerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tool", "UserID");
            AddForeignKey("dbo.Tool", "UserID", "dbo.Owner", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tool", "UserID", "dbo.Owner");
            DropIndex("dbo.Tool", new[] { "UserID" });
            AlterColumn("dbo.Tool", "OwnerID", c => c.String(maxLength: 128));
            DropColumn("dbo.Tool", "UserID");
            CreateIndex("dbo.Tool", "OwnerID");
            AddForeignKey("dbo.Tool", "OwnerID", "dbo.Owner", "UserId");
        }
    }
}
