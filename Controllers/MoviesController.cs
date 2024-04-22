using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.FirstMVC._2024.Models;
using Project.FirstMVC._2024.Services.ServicesContracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.FirstMVC._2024.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movSer;

        public MoviesController(IMovieService movSer)
        {
            _movSer = movSer;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            /* List<Movie> movies = new List<Movie>()
             {
                 new Movie {Id=1, Name="Movie 1"},
                 new Movie {Id=2, Name="Movie 2"}

             };*/
            /*var movies = appDbContext.movies.ToList();
            return View(movies);*/
            var movieItems = _movSer
                .GetAllMovies();
            return View(movieItems);
        }
    }
}

