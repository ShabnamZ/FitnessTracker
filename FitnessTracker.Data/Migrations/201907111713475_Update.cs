namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exercise", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercise", "Duration", c => c.Single(nullable: false));
        }
    }
}
