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
            var service = new ExerciseService(userId);
            var model = service.GetExercise();

            return View(model);
        }

        //GET Method
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateExerciseService();

            if (service.CreateExercise(model))
              {
                TempData["SaveResult"]= "Your note was created.";
                 return RedirectToAction("Index");
             };

            ModelState.AddModelError("", "Note could not be created");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateExerciseService();
            var model = svc.GetExerciseById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateExerciseService();
            var detail = service.GetExerciseById(id);
            var model =
                new ExerciseEdit
                {
                    ExerciseId = detail.ExerciseId,
                    NameOfExercise = detail.NameOfExercise,
                    Duration = detail.Duration,
                    TypeOfExercise = detail.TypeOfExercise,
                    DifficultyLevel = detail.DifficultyLevel
                };
            return View(model);
        }
        private ExerciseService CreateExerciseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExerciseService(userId);
            return service;
        }
    }
}