﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string TrainerName { get; set; }
       
        public string Description { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

    }
}
