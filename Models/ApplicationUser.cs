using System;
using Microsoft.AspNetCore.Identity;

namespace Project.FirstMVC._2024.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
		}
		public string City { get; set; }
	}
}

