namespace ChoreScore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimenullissue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chores", "CompletedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chores", "CompletedDate", c => c.DateTime(nullable: false));
        }
    }
}
