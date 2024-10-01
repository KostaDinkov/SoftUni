using CinemaWebApp.Data;
using CinemaWebApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Controllers
{
    public class MoviesController(CinemaDbContext dbContext) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movies = await dbContext.Movies.ToListAsync();
            return View(movies);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await dbContext.Movies.FindAsync(id);
            if(movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                return View(movie);
            }
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var movie = dbContext.Movies.Find(id);
            if(movie == null)
            {
                return NotFound();
            }
            dbContext.Movies.Remove(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
