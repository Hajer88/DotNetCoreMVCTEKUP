using System;
using Microsoft.EntityFrameworkCore;
using Project.FirstMVC._2024.Models;
using Project.FirstMVC._2024.Repositories.RepositoriesContract;

namespace Project.FirstMVC._2024.Repositories.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;
        public MovieRepository(AppDbContext _db)
        {
            this._db = _db;
        }

        public List<Movie> GetAllMovies()
        {
            var c = _db.movies.ToList();
            return c;
            //Test git
        }

        public List<Movie> GetMoviesByGenre(string name)
        {
            var d = _db.movies
                .Include(c => c.Genre)
            .Where(c => c.Genre.name == name)
            .ToList();

            return d;
        }

        //nombre films par genre
        public Dictionary<string, int> GetMovieCountByG()
        {
            
            var MoviCount = _db.genres
                .Include(c => c.movies)
                .Select(genre => new
                {
                    Name = genre.name,
                    MoviCount = genre.movies.Count()
                })
                .ToDictionary(x => x.Name, x => x.MoviCount);

            return MoviCount;
        }
    }
}

