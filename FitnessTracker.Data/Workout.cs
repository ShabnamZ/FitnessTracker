using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data
{
    public enum DaysOfWeek
    {
     Sunday=1,
     Monday,
     Tuesday,
     Wednesday,  
     Thursday,
     Friday,
     Saturday
    }
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name =" Workout")]
        public string NameOfWorkout { get; set; }

        [Display(Name ="Favorite")]
        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [ForeignKey("Exercise")]
        [Required]
        [Display(Name = "Exercise Id")]
        public int ExerciseId { get; set; }
        [ForeignKey("Trainer")]
        [Required]
        [Display(Name = "Trainer ID")]
        public int TrainerId { get; set; }
        [Required]
        public DaysOfWeek  Day { get; set; }
        public  DateTime  DayOfWorkout{ get; set; }
        public int Duration { get; set; }
        public virtual Exercise Exercise { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
