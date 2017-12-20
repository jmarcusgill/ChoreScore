namespace ChoreScore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class choreRewardUsertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChoreName = c.String(),
                        PointsAssigned = c.Single(nullable: false),
                        isAssigned = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        CompletedDate = c.DateTime(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        isRedeemed = c.Boolean(nullable: false),
                        PointValue = c.Single(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CurrentPoints", c => c.Single(nullable: false));
            AddColumn("dbo.AspNetUsers", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rewards", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chores", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rewards", new[] { "user_Id" });
            DropIndex("dbo.Chores", new[] { "user_Id" });
            DropColumn("dbo.AspNetUsers", "isActive");
            DropColumn("dbo.AspNetUsers", "CurrentPoints");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Rewards");
            DropTable("dbo.Chores");
        }
    }
}
