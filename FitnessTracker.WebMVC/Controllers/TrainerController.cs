using FitnessTracker.Models;
using FitnessTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessTracker.WebMVC.Controllers
{
   [Authorize]
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrainerService(userId);
            var model = service.GetTrainer();

            return View(model);
        }

        //GET Method
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainerCreate model)
        {
            if (!ModelState.IsValid)  return View(model);
            
            var service = CreateTrainerService();

            if (service.CreateTrainer(model))
            {
                TempData["SaveResult"] = "Your trainer was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Trainer could not be created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateTrainerService();
            var model = svc.GetTrainerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTrainerService();
            var detail = service.GetTrainerById(id);
            var model =
                new TrainerEdit
                {
                    TrainerId = detail.TrainerId,
                    TrainerName = detail.TrainerName,
                    WorkoutId = detail.WorkoutId
                };
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTrainerService();
            var model = svc.GetTrainerById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,TrainerEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.TrainerId != id)
            {
                ModelState.AddModelError("", "IdMismatch");
                return View(model);
            }
            var service = CreateTrainerService();

            if (service.UpdateTrainer(model))
            {
             TempData["SaveResult"] = "Your trainer was updated.";
              return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your trainer could not be updated.");
            return View(model);
        }

        private TrainerService CreateTrainerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrainerService(userId);
            return service;
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTrainerService();

            service.DeleteTrainer(id);

            TempData["SaveResult"] = "Your trainer was deleted";

            return RedirectToAction("Index");
        }
    }
}