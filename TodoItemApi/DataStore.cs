using System;
using System.Collections.Generic;
using TodoItemApi.Models;
using System.Linq;

namespace TodoItemApi
{
    public class ListDataSource : IDataSource 
    {
        public List<CityDto> Cities { get; set; }
        public List<PointOfInterestDto> PointOfInterests { get; set; }

        public static ListDataSource Instance { get; } = new ListDataSource();

        private ListDataSource()
        {
            InitializeData();
        }

        public CityDto GetCityById(int id)
            => Instance.Cities.FirstOrDefault(city => city.Id == id);

        public PointOfInterestDto GetPointOfInterestById(int id)
            => Instance.PointOfInterests.FirstOrDefault(interest => interest.Id == id);

        public ICollection<PointOfInterestDto> GetPointOfInterestByCityId(int idCity)
            => Instance.PointOfInterests.FindAll(pointOfInterests => idCity == pointOfInterests.IdCity);

        private void InitializeData()
        {
            InitializeCities();
            InitializePointsOfInterest();
        }

        private void InitializeCities()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Boston",
                    Description = "A great place to live"
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "New York",
                    Description = "Capital of the world"
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Chicago",
                    Description = "The wind city"
                }
            };
        }

        private void InitializePointsOfInterest()
        {
            PointOfInterests = new List<PointOfInterestDto>()
            {
                new PointOfInterestDto()
                {
                    Id = 1,
                    Name = "Fenway Park",
                    Description = "Home of Boston Red Sox",
                    IdCity = 1
                },
                new PointOfInterestDto()
                {
                    Id = 2,
                    Name = "Yankee Stadium",
                    Description = "Home of New York Yankees",
                    IdCity = 2

                },
                new PointOfInterestDto()
                {
                    Id = 3,
                    Name = "U.S. Cellular Field",
                    Description = "Home of Chicago White Sox",
                    IdCity = 3

                },
                new PointOfInterestDto()
                {
                    Id = 4,
                    Name = "Citi Field",
                    Description = "Home of New York Mets",
                    IdCity = 2

                },
                new PointOfInterestDto()
                {
                    Id = 5,
                    Name = "Wrigley Field",
                    Description = "Home of Chicago Cubs",
                    IdCity = 3

                },
                new PointOfInterestDto()
                {
                    Id = 6,
                    Name = "Brooklyn Bridge",
                    Description = "A great place for a walk",
                    IdCity = 2

                },
                new PointOfInterestDto()
                {
                    Id = 7,
                    Name = "Harvard University",
                    Description = "Best College of the world",
                    IdCity = 1

                },
            };
        }

        //TODO: Method to generate id independient of the list used
    }
}
