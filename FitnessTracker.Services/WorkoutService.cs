using FitnessTracker.Data;
using FitnessTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services
{
    public class WorkoutService
    {
        private readonly Guid _userId;

        public WorkoutService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWorkout(WorkoutCreate model)
        {
            var entity =
                new Workout()
                {
                    OwnerId = _userId,
                    NameOfWorkout = model.NameOfWorkout,
                    ExerciseId = model.ExerciseId,
                    Day = model.Day
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Workouts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkoutListItem> GetWorkout()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                     .Workouts
                     .Where(entity => entity.OwnerId == _userId)
                     .Select(
                         entity =>
                         new WorkoutListItem
                         {
                             WorkoutId = entity.WorkoutId,
                             NameOfWorkout = entity.NameOfWorkout,
                             ExerciseId = entity.ExerciseId,
                             Day = entity.Day
                         }
                     );
                return query.ToList();
            }
        }

        public WorkoutDetail GetWorkoutById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workouts
                    .Single(e => e.WorkoutId == id && e.OwnerId == _userId);
                return
                    new Models.WorkoutDetail
                    {
                        WorkoutId = entity.WorkoutId,
                        NameOfWorkout = entity.NameOfWorkout,
                        ExerciseId = entity.ExerciseId,
                        ExerciseName = entity.Exercise.NameOfExercise,
                        Day = entity.Day

                    };
            }
        }

        public bool UpdateWorkout(WorkoutEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Workouts
                        .Single(e => e.WorkoutId == model.WorkoutId && e.OwnerId == _userId);

                entity.WorkoutId = model.WorkoutId;
                entity.NameOfWorkout = model.NameOfWorkout;
                entity.ExerciseId = model.ExerciseId;
                entity.Day = model.Day;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWorkout(int workoutId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Workouts
                        .Single(e => e.WorkoutId == workoutId && e.OwnerId == _userId);

                ctx.Workouts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
