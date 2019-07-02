using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class ExerciseCreate
    {
        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters.")]
        [MaxLength(80, ErrorMessage = "There are too many characters in this field.")]
        public string NameOfExercise { get; set; }
        public float Duration{ get; set; }
        [Required]
        public ExerciseType TypeOfExercise{ get; set; }
        [Required]
        public Difficulty DifficultyLevel { get; set; }

    }
}
