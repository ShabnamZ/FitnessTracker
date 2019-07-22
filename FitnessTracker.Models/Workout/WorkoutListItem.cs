using FitnessTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models
{
    public class WorkoutListItem
    {
        [Key]
        [Display(Name ="Workout ID")]
        public int WorkoutId { get; set; }
       // [Required]
       // public Guid UserId { get; set; }
        [Required]
        [Display(Name = "Workout")]
        public string NameOfWorkout { get; set; }

        [UIHint("Starred")]
        [Display(Name ="Favorite")]
        public bool IsStarred { get; set; }

        [Required]
        [Display(Name = "Workout ")]
        public string WorkoutName { get; set; }

        [ForeignKey("Exercise")]
        [Required]
        [Display(Name = "Exercise ID")]
        public int ExerciseId { get; set; }
        public int TrainerId { get; set; }
        [Display(Name ="Trainer")]
        public string TrainerName { get; set; }

        [Required]
        public DaysOfWeek Day { get; set; }
        [Display(Name ="Date")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime DayOfWorkout { get; set; }
        public int Duration { get; set; }
        public int TotalDuration { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
