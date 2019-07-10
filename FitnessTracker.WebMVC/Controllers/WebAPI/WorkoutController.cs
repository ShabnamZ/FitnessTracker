using FitnessTracker.Models;
using FitnessTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitnessTracker.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Workout")]
    public class WorkoutController : ApiController
    {
        private bool SetStarState(int workoutId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(userId);

            // Get the workout
            var detail = service.GetWorkoutById(workoutId);

            // Create the WorkoutEdit model instance with the new star state
            var updatedWorkout =
                new WorkoutEdit
                {
                    WorkoutId = detail.WorkoutId,
                    NameOfWorkout = detail.NameOfWorkout,
                    IsStarred = newState,
                    TrainerId = detail.TrainerId,
                    Day = detail.Day,
                    DayOfWorkout =detail.DayOfWorkout
                };

            // Return a value indicating whether the update succeeded
            return service.UpdateWorkout(updatedWorkout);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
