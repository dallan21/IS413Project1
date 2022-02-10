using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IS413Project1.Models;
using Microsoft.EntityFrameworkCore;
namespace IS413Project1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NewTaskContext _taskcontext { get; set; }
        public HomeController(ILogger<HomeController> logger, NewTaskContext task)
        {
            _logger = logger;
            _taskcontext = task;
        }
        public IActionResult Index()
        {
            return View();
        }
        //The get method
        [HttpGet]
        public IActionResult NewTaskForm()
        {
            ViewBag.Categories = _taskcontext.categories.ToList();
            return View();
        }
        //And the post that sends the results to the database
        [HttpPost]
        public IActionResult NewTaskForm(NewTaskForm at)
        {
            if (ModelState.IsValid)
            {
                _taskcontext.Add(at);
                _taskcontext.SaveChanges();
                return View("Confirmation", at);
            }
            else
            {
                ViewBag.Categories = _taskcontext.categories.ToList();
                return View();
            }
        }
        public IActionResult ListQuadrant()
        {
            var tasks = _taskcontext.responses
                .Include(x => x.Category)
                .Where(x => x.Completed != true) //fix this
                .OrderBy(x => x.Task)
                .ToList();
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = _taskcontext.categories.ToList();
            var task = _taskcontext.responses.Single(x => x.TaskId == taskid);
            return View("NewTaskForm", task);
        }
        [HttpPost]
        public IActionResult Edit(NewTaskForm ntf)
        {
            _taskcontext.Update(ntf);
            _taskcontext.SaveChanges();
            return RedirectToAction("ListQuadrant");
        }
        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = _taskcontext.responses.Single(x => x.TaskId == taskid);
            return View(task);
        }
        [HttpPost]
        public IActionResult Delete(NewTaskForm ntf)
        {
            _taskcontext.responses.Remove(ntf);
            _taskcontext.SaveChanges();
            return RedirectToAction("ListQuadrant");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}