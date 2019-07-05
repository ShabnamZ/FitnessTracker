using FitnessTracker.Data;
using FitnessTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services
{
    public class ExerciseService
    {
        private readonly Guid _userId;

        public ExerciseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateExercise(ExerciseCreate model)
        {
            var entity =
                new Exercise()
                {
                    OwnerId = _userId,
                    NameOfExercise = model.NameOfExercise,
                    Duration = model.Duration,
                    TypeOfExercise= model.TypeOfExercise,
                    DifficultyLevel = model.DifficultyLevel
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Exercises.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ExerciseListItem> GetExercise()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                     .Exercises
                     .Where(entity => entity.OwnerId == _userId)
                     .Select(
                         entity =>
                         new ExerciseListItem
                         {
                             ExerciseId = entity.ExerciseId,
                             NameOfExercise = entity.NameOfExercise,
                             Duration = entity.Duration,
                             TypeOfExercise = entity.TypeOfExercise,
                             DifficultyLevel = entity.DifficultyLevel
                         }
                     );
                return query.ToArray();
            }
        }

        public ExerciseDetail GetExerciseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx
                     .Exercises
                    .Single(e=> e.ExerciseId == id && e.OwnerId == _userId);
                     return
                         new ExerciseDetail
                         {
                             ExerciseId = entity.ExerciseId,
                             NameOfExercise = entity.NameOfExercise,
                             Duration = entity.Duration,
                             TypeOfExercise = entity.TypeOfExercise,
                             DifficultyLevel = entity.DifficultyLevel
                         };
            }

        }

        public bool UpdateExercise(ExerciseEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Exercises
                    .Single(e => e.ExerciseId == model.ExerciseId && e.OwnerId == _userId);

                entity.NameOfExercise = model.NameOfExercise;
                entity.Duration = model.Duration;
                entity.TypeOfExercise = model.TypeOfExercise;
                entity.DifficultyLevel = model.DifficultyLevel;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteExercise(int exerciseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseId == exerciseId && e.OwnerId == _userId);

                ctx.Exercises.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
