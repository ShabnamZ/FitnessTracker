using FitnessTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class ExerciseListItem
    {
        [Key]
        public int ExerciseId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string NameOfExercise { get; set; }
        public string ExerciseName { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        [Display(Name = "Type")]
        public ExerciseType TypeOfExercise { get; set; }
        [Required]
        [Display(Name ="Level")]
        public Difficulty DifficultyLevel { get; set; }
        public Guid OwnerId { get; set; }
    }
}
