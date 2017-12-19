namespace ChoreScore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRewardTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rewards", "RewardTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rewards", "RewardTitle");
        }
    }
}
