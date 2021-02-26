namespace ToolChest_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedsetfromtooltool : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tool", "ConditionRating");
            DropColumn("dbo.Tool", "UsabilityRating");
            DropColumn("dbo.Tool", "AccuracyRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tool", "AccuracyRating", c => c.Double(nullable: false));
            AddColumn("dbo.Tool", "UsabilityRating", c => c.Double(nullable: false));
            AddColumn("dbo.Tool", "ConditionRating", c => c.Double(nullable: false));
        }
    }
}
