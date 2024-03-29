﻿using FitnessTracker.Models;
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
    public class ExerciseController : Controller
    {
        // GET: Exercise
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
                TempData["SaveResult"] = "Your note was created.";
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExerciseEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ExerciseId != id)
            {
                ModelState.AddModelError("", "IdMismatch");
                return View(model);
            }

            var service = CreateExerciseService();

            if (service.UpdateExercise(model))
            {
                TempData["SaveResult"] = "Your exercise was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your exercise could not be updated.");
            return View(model);
        }

        //Delete GET Method and View 
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateExerciseService();
            var model = svc.GetExerciseById(id);
            return View(model);
        }
        private ExerciseService CreateExerciseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExerciseService(userId);
            return service;
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateExerciseService();

            service.DeleteExercise(id);

            TempData["SaveResult"] = "Your exercise was deleted";

            return RedirectToAction("Index");
        }
    }
}