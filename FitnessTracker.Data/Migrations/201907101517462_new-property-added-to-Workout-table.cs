namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newpropertyaddedtoWorkouttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workout", "DayOfWorkout", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workout", "DayOfWorkout");
        }
    }
}
