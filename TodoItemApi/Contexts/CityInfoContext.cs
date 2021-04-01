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

    }
}
