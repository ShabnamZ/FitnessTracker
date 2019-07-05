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
                         }
                     );
                return query.ToArray();
            }
        }
    }
}
