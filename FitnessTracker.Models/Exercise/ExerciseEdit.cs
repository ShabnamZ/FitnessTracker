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
     
        public string NameOfExercise { get; set; }
       
        public float Duration { get; set; }
    
        [Display(Name = "Type")]
        public ExerciseType TypeOfExercise { get; set; }
        public Difficulty DifficultyLevel { get; set; }
    }
}
