using FitnessTracker.Data;
using FitnessTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services
{
    public class TrainerService
    {
        private readonly Guid _userId;

        public TrainerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTrainer(TrainerCreate model)
        {
            var entity =
                new Trainer()
                {
                    OwnerId = _userId,
                    TrainerName = model.TrainerName,
                    WorkoutId = model.WorkoutId,
                    Description = model.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trainer.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TrainerListItem> GetTrainer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                     .Trainer
                     .Where(entity => entity.OwnerId == _userId)
                     .Select(
                         entity =>
                         new TrainerListItem
                         {
                             TrainerId = entity.TrainerId,
                             TrainerName = entity.TrainerName,
                             WorkoutId = entity.WorkoutId,
                             Workout = entity.Workout,
                             WorkoutName = entity.Workout.NameOfWorkout,
                             Description = entity.Description

                         }
                     );
                return query.ToList();
            }
        }

        public TrainerDetail GetTrainerById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                    .Trainer
                    .Single(e => e.TrainerId == id && e.OwnerId == _userId);
                return
                    new TrainerDetail
                    {
                        TrainerId = entity.TrainerId,
                        TrainerName = entity.TrainerName,
                        WorkoutId = entity.WorkoutId,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateTrainer(TrainerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Trainer
                    .Single(e => e.TrainerId == model.TrainerId && e.OwnerId == _userId);

                entity.TrainerId = model.TrainerId;
                entity.TrainerName = model.TrainerName;
                entity.WorkoutId = model.WorkoutId;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteTrainer(int trainerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trainer
                        .Single(e => e.TrainerId == trainerId && e.OwnerId == _userId);

                ctx.Trainer.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
