namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsetterstoratings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tool", "ConditionRating", c => c.Double(nullable: false));
            AddColumn("dbo.Tool", "UsabilityRating", c => c.Double(nullable: false));
            AddColumn("dbo.Tool", "AccuracyRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tool", "AccuracyRating");
            DropColumn("dbo.Tool", "UsabilityRating");
            DropColumn("dbo.Tool", "ConditionRating");
        }
    }
}
