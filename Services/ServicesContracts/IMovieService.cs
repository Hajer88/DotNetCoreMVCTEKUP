using System;
using Project.FirstMVC._2024.Models;

namespace Project.FirstMVC._2024.Services.ServicesContracts
{
	public interface IMovieService
	{
        List<Movie> GetAllMovies();
        List<Movie> GetMoviesByGenre(string name);
        Dictionary<string, int> GetMovieCountByG();
    }
}

