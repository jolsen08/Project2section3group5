using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private QuadrantContext quadrantContext { get; set; }

        public HomeController(ILogger<HomeController> logger, QuadrantContext someName)
        {
            _logger = logger;
            quadrantContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Quadrant()
        {
            var connor = quadrantContext.Responses;
            return View(connor);
        }

        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = quadrantContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult TaskForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                quadrantContext.Add(ar);
                quadrantContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = quadrantContext.Categories.ToList();
                return View();
            }
          
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = quadrantContext.Categories.ToList();
            var task = quadrantContext.Responses.Single(x => x.TaskID == taskid);
            return View("TaskForm", task);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            quadrantContext.Update(ar);
            quadrantContext.SaveChanges();
            return RedirectToAction("Quadrant");
        }

        //Find the related task to the id that is returned.
        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = quadrantContext.Responses.Single(x => x.TaskID == taskid);
            return View(task);
        }

        //Delete task out of the database
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            quadrantContext.Responses.Remove(ar);
            quadrantContext.SaveChanges();

            return RedirectToAction("Quadrant");
        }

        //Changes the completed field on the application response object
        public IActionResult Complete(int taskid)
        {
            var task = quadrantContext.Responses.Single(x => x.TaskID == taskid);
            task.Completed = true;
            quadrantContext.Update(task);
            quadrantContext.SaveChanges();
            return RedirectToAction("Quadrant");
        }
    }
}
