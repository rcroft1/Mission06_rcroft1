using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_rcroft1.Models
{
    public class MovieSuggestionContext : DbContext
    {
        public MovieSuggestionContext (DbContextOptions<MovieSuggestionContext> options) : base(options)
        {
            //blank
        }
        public DbSet<MovieData> Responses { get; set; }
        public DbSet<Categories> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)

        //seeding the database
        {
            mb.Entity<Categories>().HasData(
                new Categories { CategoryId = 1, CategoryName = "Action / Adventure" },
                new Categories { CategoryId = 2, CategoryName = "Comedy" },
                new Categories { CategoryId = 3, CategoryName = "Drama" },
                new Categories { CategoryId = 4, CategoryName = "Family" },
                new Categories { CategoryId = 5, CategoryName = "Horror / Suspense" },
                new Categories { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Categories { CategoryId = 7, CategoryName = "Television" },
                new Categories { CategoryId = 8, CategoryName = "VHS" }
            ) ;


            mb.Entity<MovieData>().HasData(

                    new MovieData
                    {
                        MovieId = 1,
                        title = "Puss in Boots",
                        year = 2023,
                        director = "Joel Crawford",
                        rating = "Pg",
                        CategoryId = 2
                    },
                    new MovieData
                    {
                        MovieId = 2,
                        title = "Shreck",
                        year = 2001,
                        director = "Andrew Adamson",
                        rating = "Pg",
                        notes = "Best movie ever",
                        CategoryId = 3
                    },
                    new MovieData
                    {
                        MovieId = 3,
                        title = "Shreck 2",
                        year = 2004,
                        director = "Conrad Vernon",
                        rating = "Pg",
                        notes = "Second best movie ever",
                        CategoryId = 4

                    }
                );
        }
    }
}
