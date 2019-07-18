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
        private TrainerService _trainerService;
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
            _trainerService = new TrainerService(Guid.Parse(User.Identity.GetUserId()));
            _exerciseService = new ExerciseService(Guid.Parse(User.Identity.GetUserId()));
            ViewBag.ExerciseId = new SelectList(_exerciseService.GetExercise().ToList(), "ExerciseId", "NameOfExercise");
            ViewBag.ExerciseDuration = new SelectList(_exerciseService.GetExercise().ToList(), "ExerciseId", "Duration");
            ViewBag.TrainerId = new SelectList(_trainerService.GetTrainer().ToList(), "TrainerId", "TrainerName");
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
            _trainerService = new TrainerService(Guid.Parse(User.Identity.GetUserId()));
            _exerciseService = new ExerciseService(Guid.Parse(User.Identity.GetUserId()));
            ViewBag.ExerciseId = new SelectList(_exerciseService.GetExercise().ToList(), "ExerciseId", "NameOfExercise");
            ViewBag.TrainerId = new SelectList(_trainerService.GetTrainer().ToList(), "TrainerId", "TrainerName");
            var service = CreateWorkoutService();
            var eService = CreateExerciseService();
            var tService = CreateTrainerService();
            var detail = service.GetWorkoutById(id);
            var exercises = eService.GetExercise();
            var trainers = tService.GetTrainer();
            var model =
                new WorkoutEdit
                {
                    WorkoutId = detail.WorkoutId,
                    NameOfWorkout = detail.NameOfWorkout,
                    TrainerId = detail.TrainerId,
                    ExerciseId = detail.ExerciseId,
                    Day = detail.Day,
                    Duration = detail.Duration,
                    DayOfWorkout = detail.DayOfWorkout,
                    Exercise = exercises,
                    Trainer = trainers
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
        private ExerciseService CreateExerciseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExerciseService(userId);
            return service;
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
            var service = CreateWorkoutService();

            service.DeleteWorkout(id);

            TempData["SaveResult"] = "Your workout was deleted";

            return RedirectToAction("Index");
        }

        //Method for WorkoutByDate

        public ActionResult WorkoutByDate()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(userId);
            var model = service.GetWorkout();
            List<DateTime> dateTime = new List<DateTime>();
            foreach (var workout in model)
            {
                if (!dateTime.Contains(workout.DayOfWorkout))
                {
                    dateTime.Add(workout.DayOfWorkout);
                }
            }
            return View(dateTime);
        }

        public ActionResult ByDateDetails(DateTime date)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(userId);
            var model = service.GetWorkout();
            var workoutByDate = new List<WorkoutListItem>();

            foreach( var item in model)
            {
                if(item.DayOfWorkout == date)
                {
                    workoutByDate.Add(item);
                }
            }

            return View(workoutByDate);
        }
    }
}