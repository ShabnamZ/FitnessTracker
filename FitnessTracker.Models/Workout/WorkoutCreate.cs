﻿using FitnessTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
   public  class WorkoutCreate
    {
        [Required]
        [Display(Name ="Name of workout")]
        public string NameOfWorkout { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        public DaysOfWeek Day { get; set; }
    }
}
