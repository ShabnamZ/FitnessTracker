using FitnessTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class ExerciseEdit
    {
       
        public int ExerciseId { get; set; }
        [Display(Name = "Exercise")]
        public string NameOfExercise { get; set; }
       
        public int Duration { get; set; }
    
        [Display(Name = "Type")]
        public ExerciseType TypeOfExercise { get; set; }
        [Display(Name = "Level")]
        public Difficulty DifficultyLevel { get; set; }
    }
}
