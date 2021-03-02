namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedownercustomerflags : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "IsOwner");
            DropColumn("dbo.User", "IsCustomer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "IsCustomer", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "IsOwner", c => c.Boolean(nullable: false));
        }
    }
}
