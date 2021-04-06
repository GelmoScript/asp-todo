using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoItemApi.Contexts;
using TodoItemApi.Entities;

namespace TodoItemApi.Services.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly CityInfoContext _context;

        public CityRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public City Create(City city)
        {
            var queryResult = _context.Cities.Add(city);
            _context.SaveChanges();
            return queryResult.Entity;
        }

        public City Delete(int id)
        {
            var cityToDelete = GetCityById(id);
            cityToDelete.IsDeleted = true;
            cityToDelete.DeleteDate = DateTime.Now;
            _context.SaveChanges();
            return cityToDelete;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.Where(c => !c.IsDeleted).ToList();
        }

        public City GetCityById(int id, bool includePointsOfInterest = false)
        {
            if (includePointsOfInterest)
                return _context.Cities.Where(c => c.Id == id).Include(c => c.PointsOfInterest).FirstOrDefault();
            return _context.Cities.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestFromCityId(int id)
        {
            return _context.PointOfInterests.Where(poi => poi.CityId == id).ToList();
        }

        public City Update(City city)
        {
            city.LastUpdateDate = DateTime.Now;
            _context.Cities.Update(city);
            _context.SaveChanges();
            return city;
        }
    }
}
