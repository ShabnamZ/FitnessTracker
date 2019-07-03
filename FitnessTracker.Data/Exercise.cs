using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data
{
    public enum ExerciseType
    {
    Aerobic=1,
    Strenght,
    Balance,
    Flexibility
    }
     
    public enum Difficulty
    {
        Easy=1,
        Medium,
        Hard
    }
    public class Exercise
    {
        [Key]
        [Display(Name ="ID")]
        public int ExerciseId { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string NameOfExercise { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        [Display(Name ="Type")]
        public ExerciseType TypeOfExercise { get; set;}
        [Required]
        public Difficulty DifficultyLevel { get; set; }
        [Required]
        public Guid OwnerId { get; set; }


    }
}
