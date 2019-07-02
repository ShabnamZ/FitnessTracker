using FitnessTracker.Models;
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
            var model = new TrainerListItem[0];
            return View(model);
        }

        //GET Method
        public ActionResult Create()
        {
            return View();
        }
    }
}