using FitnessTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class WorkoutEdit
    {

        public int WorkoutId { get; set; }

        [Display(Name = "Workout")]
        public string NameOfWorkout { get; set; }
        [Display(Name = "Favorite")]
        public bool IsStarred { get; set; }

        [Display(Name = "Exercise ID")]
        public int ExerciseId { get; set; }
        public IEnumerable<ExerciseListItem> Exercise { get; set; }
        public DaysOfWeek Day { get; set; }
        public DateTime DayOfWorkout { get; set; }
        public int Duration { get; set; }
        public int TrainerId { get; set; }
        public IEnumerable<TrainerListItem> Trainer { get; set; }

    }
}
