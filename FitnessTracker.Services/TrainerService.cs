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
    }
}
