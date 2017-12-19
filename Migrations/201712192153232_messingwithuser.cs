namespace ChoreScore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messingwithuser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rewards", new[] { "user_Id" });
            CreateIndex("dbo.Rewards", "User_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rewards", new[] { "User_Id" });
            CreateIndex("dbo.Rewards", "user_Id");
        }
    }
}
