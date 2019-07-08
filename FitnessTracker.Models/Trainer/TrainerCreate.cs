using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class TrainerCreate
    {
        [Required]
        public string TrainerName { get; set; }
        [Required]
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }
    }
}
