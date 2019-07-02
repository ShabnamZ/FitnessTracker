using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public enum ExerciseType
    {
        Aerobic = 1,
        Strenght,
        Balance,
        Flexibility
    }

    public enum Difficulty
    {
        Easy = 1,
        Medium,
        Hard
    }
    public class ExerciseListItem
    {
        [Key]
        public int ExerciseId { get; set; }
        [Required]
        public string NameOfExercise { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        [Display(Name = "Type")]
        public ExerciseType TypeOfExercise { get; set; }
        [Required]
        public Difficulty DifficultyLevel { get; set; }
    }
}
