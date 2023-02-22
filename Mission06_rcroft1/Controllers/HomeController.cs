using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Category = newContext.Categories.ToList();
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
                return View(md);
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
        public IActionResult movieList()
        {
            // Responses should be moviedata

            var allMovies = newContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(allMovies);
        }
        [HttpGet]
        public IActionResult Edit(int MovieId)
        {
            ViewBag.Category = newContext.Categories.ToList();

            var movie = newContext.Responses.Single(x => x.MovieId == MovieId);

            return View("NewMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieData editMD)
        {
            // identifying and editing the correct record

            newContext.Update(editMD);
            newContext.SaveChanges();
            return RedirectToAction("movieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieID)
        {
            var movie = newContext.Responses.Single(x => x.MovieId == movieID);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieData deleteMD)
        {
            // identifying and deleting the correct record

            newContext.Responses.Remove(deleteMD);
            newContext.SaveChanges();
            return RedirectToAction("movieList");
        }
    }
}

