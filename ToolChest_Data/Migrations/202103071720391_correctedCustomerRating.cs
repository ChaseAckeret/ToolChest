namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedCustomerRating : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CustomerRating", name: "CustomerUserID", newName: "FKCustomerID");
            RenameIndex(table: "dbo.CustomerRating", name: "IX_CustomerUserID", newName: "IX_FKCustomerID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CustomerRating", name: "IX_FKCustomerID", newName: "IX_CustomerUserID");
            RenameColumn(table: "dbo.CustomerRating", name: "FKCustomerID", newName: "CustomerUserID");
        }
    }
}
