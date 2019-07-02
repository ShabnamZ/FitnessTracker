using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data
{
    public enum DayOfWeek
    {
     Sunday=1,
     Monday,
     Tuesday,
     Wednesday,  
     Thursday,
     Friday,
     Saturday
    }
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Display(Name ="Name of workout")]
        public string NameOfWorkout { get; set; }
        [Required]
        [Display(Name ="Exercise ID")]
        public int ExerciseId { get; set; }
        [Required]
        public DayOfWeek  Day { get; set; }
    }
}
