using FitnessTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FitnessTracker.Models.Workout
{
    public class WorkOutCreateTestModelViewOnly
    {
        public string NameOfWorkout { get; set; }
        public int ExerciseId { get; set; }
        public DaysOfWeek Day { get; set; }
        public DateTime DayOfWorkout { get; set; }
        public int TrainerId { get; set; }
        public int Duration { get; set; }

        public List<ExerciseListItem> Exercise { get; set; }
        public TrainerListItem[] Trainer { get; set; }
    }
}
