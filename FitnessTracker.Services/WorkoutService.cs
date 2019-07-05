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
                return query.ToArray();
            }
        }
    }
}
