namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedreceiptstuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipt",
                c => new
                    {
                        FKRentalID = c.Int(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        ActualStartDate = c.DateTime(nullable: false),
                        ActualEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FKRentalID)
                .ForeignKey("dbo.Rental", t => t.FKRentalID)
                .Index(t => t.FKRentalID);
            
            AddColumn("dbo.Rental", "RecipetID", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipt", "FKRentalID", "dbo.Rental");
            DropIndex("dbo.Receipt", new[] { "FKRentalID" });
            DropColumn("dbo.Rental", "RecipetID");
            DropTable("dbo.Receipt");
        }
    }
}
