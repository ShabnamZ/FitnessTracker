namespace FitnessTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercise",
                c => new
                    {
                        ExerciseId = c.Int(nullable: false, identity: true),
                        NameOfExercise = c.String(nullable: false),
                        Duration = c.Single(nullable: false),
                        TypeOfExercise = c.Int(nullable: false),
                        DifficultyLevel = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        TrainerId = c.Int(nullable: false, identity: true),
                        TrainerName = c.String(nullable: false),
                        Description = c.String(),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.TrainerId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Workout",
                c => new
                    {
                        WorkoutId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        NameOfWorkout = c.String(nullable: false),
                        IsStarred = c.Boolean(nullable: false),
                        ExerciseId = c.Int(nullable: false),
                        TrainerId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkoutId)
                .ForeignKey("dbo.Exercise", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.Trainer", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.ExerciseId)
                .Index(t => t.TrainerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workout", "TrainerId", "dbo.Trainer");
            DropForeignKey("dbo.Workout", "ExerciseId", "dbo.Exercise");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.Workout", new[] { "TrainerId" });
            DropIndex("dbo.Workout", new[] { "ExerciseId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.Workout");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Trainer");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Exercise");
        }
    }
}
