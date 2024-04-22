using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.FirstMVC._2024.Models
{
	public class Customer
	{
		public Customer()
		{
		}
		public int Id { get; set; }
		public string Name { get; set; }
        public int? membershiptype_id { get; set; }

        [ForeignKey("membershiptype_id")]
        public virtual Membershiptype? Membershiptype { get; set; }

        public virtual ICollection<Movie>? Movies { get; set; }
    }
}

