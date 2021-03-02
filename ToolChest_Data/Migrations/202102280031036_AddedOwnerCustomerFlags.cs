namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOwnerCustomerFlags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsOwner", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "IsCustomer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "IsCustomer");
            DropColumn("dbo.User", "IsOwner");
        }
    }
}
