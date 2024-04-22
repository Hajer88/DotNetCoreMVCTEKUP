using System;
namespace Project.FirstMVC._2024.Models.ViewModels
{
	public class MoviecustomersVM
	{
		public MoviecustomersVM()
		{
		}
		public Movie movie { get; set; }
		public List<Customer> customers { get; set; }
	}
}

