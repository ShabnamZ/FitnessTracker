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

        public IEnumerable<WorkoutListItem> GetExercises()
        {
          using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Workouts
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new WorkoutListItem
                        {
                            WorkoutId = e.WorkoutId,
                            UserId = e.UserId,
                            NameOfWorkout = e.NameOfWorkout,
                            ExerciseId = e.ExerciseId,
                            Day = e.Day
                        }

                        ) ;
            }
        }
        /*   public IEnumerable<EntryListItem> GetEntries()
       {
           var query = _db.Entries.Where(existingEntry => existingEntry.OwnerId == _userId).Select(existingEntry => new EntryListItem { EntryDate = existingEntry.EntryDate, MoodRating = existingEntry.MoodRating });
           return query.ToArray();
       }*/
    }
}
