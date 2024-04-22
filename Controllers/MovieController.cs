using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.FirstMVC._2024.Models;
using Project.FirstMVC._2024.Services.ServicesContracts;

namespace Project.FirstMVC._2024
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMovieService _IMovieSer;

        public MovieController(AppDbContext context, IMovieService _IMovieSer)
        {
            _context = context;
            this._IMovieSer = _IMovieSer;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.movies.Include(m => m.Genre);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.movies == null)
            {
                return NotFound();
            }

            var movie = await _context.movies
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            ViewData["genre_id"] = new SelectList(_context.genres, "GenreId", "GenreId");
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,releaseDate,WithSubtitles,genre_id")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["genre_id"] = new SelectList(_context.genres, "GenreId", "GenreId", movie.genre_id);
            return View(movie);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.movies == null)
            {
                return NotFound();
            }

            var movie = await _context.movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["genre_id"] = new SelectList(_context.genres, "GenreId", "GenreId", movie.genre_id);
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,releaseDate,WithSubtitles,genre_id")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["genre_id"] = new SelectList(_context.genres, "GenreId", "GenreId", movie.genre_id);
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.movies == null)
            {
                return NotFound();
            }

            var movie = await _context.movies
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.movies == null)
            {
                return Problem("Entity set 'AppDbContext.movies'  is null.");
            }
            var movie = await _context.movies.FindAsync(id);
            if (movie != null)
            {
                _context.movies.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Route("{name}")]
        [HttpGet]
        public  IActionResult MoviesByGenreList(string name)
        {
            var mByG = _IMovieSer.GetMoviesByGenre(name);
            return View(mByG);
        }
        //Ecrire un service permettant de charger un fichier PDf
        [Route("DownloadFile")]
        [HttpGet]
        public IActionResult DownloadFile()
        {
            byte[] bytes = System.IO.File
                .ReadAllBytes(@"/Users/hajertaktak/Desktop/Atelier 1 Introduction ASP.Net Core MVC.pdf");
            return File(bytes, "Application/pdf");
        }
        //Get Movies Grouped By Genre
        
        public IActionResult MovieCount()
        {
            var c = _IMovieSer.GetMovieCountByG();
            return View(c);

             
        }
        private bool MovieExists(int id)
        {
          return (_context.movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
