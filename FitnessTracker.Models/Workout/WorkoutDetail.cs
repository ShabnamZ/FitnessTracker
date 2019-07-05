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
        [Display(Name = "Name of workout")]
        public string NameOfWorkout { get; set; }
        [Required]
        [Display(Name = "Exercise ID")]
        public int ExerciseId { get; set; }
        [Required]
        public DaysOfWeek Day { get; set; }
    }
}
