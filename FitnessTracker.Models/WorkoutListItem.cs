using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public enum DayOfWeek
    {
        Sunday = 1,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    public class WorkoutListItem
    {
        [Key]
        public int WorkoutId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string NameOfWorkout { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        [Required]
        public DayOfWeek Day { get; set; }
    }
}
