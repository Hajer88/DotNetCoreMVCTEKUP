using System;
using Project.FirstMVC._2024.Models;
using Project.FirstMVC._2024.Repositories.RepositoriesContract;
using Project.FirstMVC._2024.Services.ServicesContracts;

namespace Project.FirstMVC._2024.Services.Services
{
	public class MovieService : IMovieService
	{
        private readonly IMovieRepository _repo;

		public MovieService(IMovieRepository repo)
		{
            _repo = repo;
		}

		public List<Movie> GetAllMovies()
		=> _repo.GetAllMovies();

		public Dictionary<string, int> GetMovieCountByG()
        => _repo.GetMovieCountByG();

        public List<Movie> GetMoviesByGenre(string name)
			=> _repo.GetMoviesByGenre(name);
    }
}

