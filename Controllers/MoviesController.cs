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
                         join a in FakeDatabase.ActorsInMovies on m.ActorId equals a.ActorId
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
