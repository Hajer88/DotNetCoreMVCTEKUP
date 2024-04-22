using System;
using Microsoft.EntityFrameworkCore;

namespace Project.FirstMVC._2024.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			:base(options)
		{
		}
		public DbSet<Movie> movies { get; set; }
		public DbSet<UserModel> userModels { get; set; }
		public DbSet<Genre> genres { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Membershiptype> Membershiptypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string GenreJSon = System.IO.File.ReadAllText("GenreFile.Json");
            List<Genre>? genres = System.Text.Json.
            JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            //Seed to categorie
            foreach (Genre c in genres)
                modelBuilder.Entity<Genre>()
                .HasData(c);
        }
    }
}

