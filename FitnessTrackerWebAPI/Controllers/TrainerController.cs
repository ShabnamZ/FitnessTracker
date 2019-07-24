using FitnessTracker.Models;
using FitnessTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitnessTrackerWebAPI.Controllers
{
    [Authorize]
    public class TrainerController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            TrainerService trainerService = CreateTrainerService();
            var trainers = trainerService.GetTrainer();
            return Ok(trainers);
        }

        public IHttpActionResult Get(int id)
        {
            TrainerService trainerService = CreateTrainerService();
            var trainer = trainerService.GetTrainerById(id);
            return Ok(trainer);
        }

        public IHttpActionResult Post(TrainerCreate trainer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTrainerService();

            if (!service.CreateTrainer(trainer))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(TrainerEdit trainer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTrainerService();

            if (!service.UpdateTrainer(trainer))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTrainerService();

            if (!service.DeleteTrainer(id))
                return InternalServerError();
            return Ok();
        }
        private TrainerService CreateTrainerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var trainerService = new TrainerService(userId);
            return trainerService;
        }
    }
}
    

