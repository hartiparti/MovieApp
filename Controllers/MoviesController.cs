using System.Diagnostics;
using System.Linq;
using System;
using System.Collections.Generic;
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
