using System;
using System.Collections.Generic;
using TodoItemApi.Models;

namespace TodoItemApi.Services
{
    public interface IDataSource
    {
        public List<CityDto> Cities { get; set; }
        public List<PointOfInterestDto> PointOfInterests { get; set; }

        public CityDto GetCityById(int id);
        public PointOfInterestDto GetPointOfInterestById(int id);
        public ICollection<PointOfInterestDto> GetPointOfInterestByCityId(int idCity);
    }
}
