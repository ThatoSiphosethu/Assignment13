using Microsoft.EntityFrameworkCore;
using Assignment13.DataModels;

namespace Assignment13.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<Genre> Genres {get;set;}
        public DbSet<Movie> Movies {get;set;}
        public DbSet<MovieGenre> MovieGenres {get;set;}
        public DbSet<Occupation> Occupations {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<UserMovie> UserMovies {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                // optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=bitsql.wctc.edu;Database=mmcarthey_22097_Movie;User ID=mmcarthey;Password=000075813;");
                optionsBuilder.UseSqlServer(@"Server=bitsql.wctc.edu;Database=tramalepa_22097_MovieA13;User ID=tramalepa;Password=000558972;");
        }
    }
}