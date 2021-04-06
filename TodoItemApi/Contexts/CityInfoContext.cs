using System;
using Microsoft.EntityFrameworkCore;
using TodoItemApi.Entities;

namespace TodoItemApi.Contexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }

        public CityInfoContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
                    new City()
                    {
                        Id = 1,
                        Name = "Boston",
                        Description = "A great place to live"
                    },
                    new City()
                    {
                        Id = 2,
                        Name = "New York",
                        Description = "Capital of the world"
                    },
                    new City()
                    {
                        Id = 3,
                        Name = "Chicago",
                        Description = "The wind city"
                    }
                );

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                    new PointOfInterest()
                    {
                        Id = 1,
                        Name = "Fenway Park",
                        Description = "Home of Boston Red Sox",
                        CityId = 1
                    },
                    new PointOfInterest()
                    {
                        Id = 2,
                        Name = "Yankee Stadium",
                        Description = "Home of New York Yankees",
                        CityId = 2

                    },
                    new PointOfInterest()
                    {
                        Id = 3,
                        Name = "U.S. Cellular Field",
                        Description = "Home of Chicago White Sox",
                        CityId = 3

                    },
                    new PointOfInterest()
                    {
                        Id = 4,
                        Name = "Citi Field",
                        Description = "Home of New York Mets",
                        CityId = 2

                    },
                    new PointOfInterest()
                    {
                        Id = 5,
                        Name = "Wrigley Field",
                        Description = "Home of Chicago Cubs",
                        CityId = 3

                    },
                    new PointOfInterest()
                    {
                        Id = 6,
                        Name = "Brooklyn Bridge",
                        Description = "A great place for a walk",
                        CityId
                        = 2

                    },
                    new PointOfInterest()
                    {
                        Id = 7,
                        Name = "Harvard University",
                        Description = "Best College of the world",
                        CityId = 1

                    }
                );
        }

    }
}
