using FitnessTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class WorkoutDetail
    {
        [Key]
        public int WorkoutId { get; set; }
        [Required]
        [Display(Name = "Workout")]
        public string NameOfWorkout { get; set; }
        [Required]
        [Display(Name = "Exercise ID")]
        public int ExerciseId { get; set; }
        [Display(Name ="Exercise")]
        public string ExerciseName { get; set; }
        [Required]
        public DaysOfWeek Day { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DayOfWorkout { get; set; }
        public int Duration { get; set; }
        public int TrainerId { get; set; }
        [Display(Name ="Trainer")]
        public string TrainerName { get; set; }
    }
}
