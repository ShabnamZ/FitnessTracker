using FitnessTracker.Data;
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
    public class WorkoutController : Controller
    {
        private WorkoutService _workoutService;
        private ExerciseService _exerciseService;
        // GET: Trainer
        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(userId);
            var model = service.GetWorkout();

            return View(model);
        }

        //GET Method
        public ActionResult Create()
        {
            _workoutService = new WorkoutService(Guid.Parse(User.Identity.GetUserId()));
            _exerciseService = new ExerciseService(Guid.Parse(User.Identity.GetUserId()));
            ViewBag.ExerciseId = new SelectList(_exerciseService.GetExercise().ToList(), "ExerciseId", "NameOfExercise");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkoutCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWorkoutService();

            if (service.CreateWorkout(model))
            {
                TempData["SaveResult"] = "Your workout was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Workout could not be created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateWorkoutService();
            var model = svc.GetWorkoutById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            _workoutService = new WorkoutService(Guid.Parse(User.Identity.GetUserId()));
            _exerciseService = new ExerciseService(Guid.Parse(User.Identity.GetUserId()));
            ViewBag.ExcerciseId = new SelectList(_exerciseService.GetExercise().ToList(), "ExerciseId", "ExerciseName");
            var service = CreateWorkoutService();
            var detail = service.GetWorkoutById(id);
            var model =
                new WorkoutEdit
                {
                    WorkoutId = detail.WorkoutId,
                    NameOfWorkout = detail.NameOfWorkout,
                    ExerciseId= detail.ExerciseId,
                    Day = detail.Day
                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWorkoutService();
            var model = svc.GetWorkoutById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkoutEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.WorkoutId != id)
            {
                ModelState.AddModelError("", "IdMismatch");
                return View(model);
            }
            var service = CreateWorkoutService();

            if (service.UpdateWorkout(model))
            {
                TempData["SaveResult"] = "Your workout was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your workout could not be updated.");
            return View(model);
        }

        private WorkoutService CreateWorkoutService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(userId);
            return service;
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWorkoutService();

            service.DeleteWorkout(id);

            TempData["SaveResult"] = "Your workout was deleted";

            return RedirectToAction("Index");
        }
    }
}