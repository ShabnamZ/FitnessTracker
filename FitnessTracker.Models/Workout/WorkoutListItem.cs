using FitnessTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class WorkoutListItem
    {
        [Key]
        [Display(Name ="Workout ID")]
        public int WorkoutId { get; set; }
       // [Required]
       // public Guid UserId { get; set; }
        [Required]
        [Display(Name = "Name of Workout ")]
        public string NameOfWorkout { get; set; }
        [Required]
        [Display(Name = "Exercise ID ")]
        public string WorkoutName { get; set; }
        public int ExerciseId { get; set; }
        [Required]
        public DaysOfWeek Day { get; set; }
    }
}
