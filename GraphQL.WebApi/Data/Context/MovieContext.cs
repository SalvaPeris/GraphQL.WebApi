using GraphQL.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.WebApi.Data.Context
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Reviews
            modelBuilder.Entity<Movie>().OwnsMany(m => m.Reviews).HasData(
                new Review
                {
                    Id = 1,
                    Reviewer = "A",
                    Stars = 4,
                    MovieId = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd")
                },
                new Review
                {
                    Id = 2,
                    Reviewer = "B",
                    Stars = 1,
                    MovieId = new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51")
                }
            );
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"),
                    Name = "Superman and Lois"
                },
                new Movie
                {
                    Id = new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"),
                    Name = "Avengers: Endgame"
                }
            );
        }
    }
}
