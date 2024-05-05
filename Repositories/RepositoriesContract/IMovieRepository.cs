using System;
using Project.FirstMVC._2024.Models;

namespace Project.FirstMVC._2024.Repositories.RepositoriesContract
{
	public interface IMovieRepository
	{
		List<Movie> GetAllMovies();
		List<Movie> GetMoviesByGenre(string name);
		Dictionary<string, int> GetMovieCountByG();




		List<Movie> GetMovieesByGenre2(string name);


		List<Movie> GetMoviesByG(string name);
















    }
}

