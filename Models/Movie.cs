using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.FirstMVC._2024.Models
{
	public class Movie
	{
		
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime releaseDate{ get; set; }

		public bool WithSubtitles { get; set; }

        public int? genre_id { get; set; }

        [ForeignKey("genre_id")]
        public virtual Genre? Genre { get; set; }

		public virtual ICollection<Customer>? Customers { get; set; }
    }
}

