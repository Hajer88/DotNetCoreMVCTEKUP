using System;
namespace Project.FirstMVC._2024.Models
{
	public class Genre
	{
	
		public int GenreId { get; set; }

		public string name { get; set; }

		public virtual IEnumerable<Movie>? movies { get; set; }
	}
}

