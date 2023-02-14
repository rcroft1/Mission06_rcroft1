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
        public DbSet<MovieData> responses { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieData>().HasData(

                    new MovieData
                    {
                        MovieId = 1,
                        title = "Puss in Boots",
                        year = 2023,
                        director = "Joel Crawford",
                        rating = "Pg"
                    },
                    new MovieData
                    {
                        MovieId = 2,
                        title = "Shreck",
                        year = 2001,
                        director = "Andrew Adamson",
                        rating = "Pg",
                        notes = "Best movie ever"
                    },
                    new MovieData
                    {
                        MovieId = 3,
                        title = "Shreck 2",
                        year = 2004,
                        director = "Conrad Vernon",
                        rating = "Pg",
                        notes = "Second best movie ever"
                    }
                );
        }
    }
}
