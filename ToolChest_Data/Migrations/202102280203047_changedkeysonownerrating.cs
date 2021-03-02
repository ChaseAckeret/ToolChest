namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedkeysonownerrating : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OwnerRating", name: "OwnerUserID", newName: "FKOwnerID");
            RenameIndex(table: "dbo.OwnerRating", name: "IX_OwnerUserID", newName: "IX_FKOwnerID");
            DropColumn("dbo.OwnerRating", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OwnerRating", "OwnerId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.OwnerRating", name: "IX_FKOwnerID", newName: "IX_OwnerUserID");
            RenameColumn(table: "dbo.OwnerRating", name: "FKOwnerID", newName: "OwnerUserID");
        }
    }
}
