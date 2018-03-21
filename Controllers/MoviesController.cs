using System.Diagnostics;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Models.ViewModels;
namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {   
            var mv_db = (from mov in FakeDatabase.Movies
                        select new MovieViewModel
                         {
                             Id = mov.Id,
                             Title = mov.Title,
                             Genre = mov.Genre,
                             Rating = mov.Rating
                         }).ToList();
            
            return View(mv_db);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {   
            if(id == null)
            {
                return View("Error");
            }

            var mv_db = (from m in FakeDatabase.Movies
                         where m.Id == id
                         select new MovieViewModel
                         {
                             Id = m.Id,
                             Title = m.Title,
                             Genre = m.Genre,
                             ReleaseYear = m.ReleaseYear,
                             Rating = m.Rating,
                             Image = m.Image,
                         }).FirstOrDefault();

            var movieActors = (from am in FakeDatabase.ActorsInMovies
                         join a in FakeDatabase.Actors on am.ActorId equals a.Id
                         where am.MovieId == id
                         select new ActorViewModel 
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Age = a.Age
                         }).ToList();
           
           movie.Actors = movieActors; 

            if(mv_db == null)
            {
                return View("Error");
            }
            return View(mv_db);
        }


        [HttpGet]
        public IActionResult TopFiveMovies()
        {
                   var mv_db = (from mov in FakeDatabase.Movies
                        orderby mov.Rating descending
                        select new MovieViewModel
                         {
                             Id = mov.Id,
                             Title = mov.Title,
                             Rating = mov.Rating
                             
                         }).Take(5);
            
            return View(mv_db);
        }
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
