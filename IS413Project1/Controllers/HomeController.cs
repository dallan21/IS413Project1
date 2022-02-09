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
            _taskcontext.Add(at);
            _taskcontext.SaveChanges();

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
