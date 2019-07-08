namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Workout", "ExerciseId");
            AddForeignKey("dbo.Workout", "ExerciseId", "dbo.Exercise", "ExerciseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workout", "ExerciseId", "dbo.Exercise");
            DropIndex("dbo.Workout", new[] { "ExerciseId" });
        }
    }
}
