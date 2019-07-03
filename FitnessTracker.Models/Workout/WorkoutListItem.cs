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
        public int WorkoutId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string NameOfWorkout { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        [Required]
        public DaysOfWeek Day { get; set; }
    }
}
