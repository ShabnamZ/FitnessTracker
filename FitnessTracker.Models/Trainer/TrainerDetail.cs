using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class TrainerDetail
    {
        
        public int TrainerId { get; set; }
        
        [Display(Name = "Name")]
        public string TrainerName { get; set; }
       
        [Display(Name = "Workout ID")]
        public int WorkoutId { get; set; }
        public string Description { get; set; }
    }
}
