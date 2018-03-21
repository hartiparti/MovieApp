using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MovieApp.Models.ViewModels;

using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class ActorsController : Controller
    {   
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Details(int? id)
        {   
            if(id == null)
            {
                return View("Error");
            }

            var mv_db = (from mov in FakeDatabase.Movies
                         join am in FakeDatabase.ActorsInMovies on mov.Id equals am.MovieId
                         join a in FakeDatabase.Actors on am.ActorId equals a.Id
                         where mov.Id == id
                         select new MovieViewModel 
                         {
                             Id = mov.Id,
                             Title = mov.Title,
                             Genre = mov.Genre,
                             ReleaseYear = mov.ReleaseYear,
                             Rating = mov.Rating,
                             Image = mov.Image,
                             ActorId = a.Id,
                             ActorName = a.Name            
                         }).ToList();
        
            if(mv_db == null)
            {
                return View("Error");
            }
            return View(mv_db);
        }
    }
}
