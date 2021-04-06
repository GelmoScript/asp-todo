using System;
using System.Collections.Generic;
using TodoItemApi.Entities;

namespace TodoItemApi.Services.Repositories
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities();
        IEnumerable<PointOfInterest> GetPointsOfInterestFromCityId(int id);
        City GetCityById(int id, bool includePointsOfInterest = false);
        City Create(City city);
        City Update(City city);
        City Delete(int id);
    }
}
