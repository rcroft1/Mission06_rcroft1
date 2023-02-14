using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_rcroft1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_rcroft1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieSuggestionContext newContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieSuggestionContext suggestion)
        {
            _logger = logger;
            newContext = suggestion;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        // overloading newMovie with a get and a post

        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMovie(MovieData md)
        {
            if (ModelState.IsValid)
            {
                newContext.Add(md);
                newContext.SaveChanges();

                // returns the confirmation page

                return View("Confirmation");
            }
            else
            {
                return View();
            }
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
    }
}
