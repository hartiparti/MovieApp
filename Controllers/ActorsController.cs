using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Models.ViewModels;
using MovieApp.Models.InputModels;
using MovieApp.Models.EntityModels;

namespace MovieApp.Controllers
{
    public class ActorsController : Controller
    {   
        [HttpGet]
  
        public IActionResult Index()
        {   
            var a_db = (from a in FakeDatabase.Actors
                        select new ActorViewModel
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Age = a.Age,

                         }).ToList();
            
            return View(a_db);
        }
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
