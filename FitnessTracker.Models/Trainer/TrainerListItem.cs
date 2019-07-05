using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class TrainerListItem
    {
        [Key]
        public int TrainerId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string TrainerName { get; set; }
        [Required]
        public int WorkoutId { get; set; }
      /*  [Required]
        public int OwnerId { get; set; }*/
    }
}
