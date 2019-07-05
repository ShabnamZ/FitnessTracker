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
        
        [Display(Name = "Name of workout")]
        public string NameOfWorkout { get; set; }
        
        [Display(Name = "Exercise ID")]
        public int ExerciseId { get; set; }
        
        public DaysOfWeek Day { get; set; }
    }
}
