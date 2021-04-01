using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoItemApi.Models;
using TodoItemApi.Services;


namespace TodoItemApi.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private IDataSource _source;

        public CitiesController(IDataSource source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _source.Cities;
            return new JsonResult(cities);
        }

        [HttpGet("{cityId}")]
        public IActionResult GetCityById(int cityId)
        {
            var city = _source.GetCityById(cityId);
            return new JsonResult(city);
        }

        [HttpGet("{cityId}/interests")]
        public IActionResult GetCityPointsOfInterest(int cityId)
        {
            var pointOfInterest = _source.GetPointOfInterestByCityId(cityId);
            return new JsonResult(pointOfInterest);
        }

        [HttpPost]
        public IActionResult PostCity(CityDto city)
        {
            var listOfCities = _source.Cities;
            int newCityId = GenerateCityId();
            city.Id = newCityId;
            listOfCities.Add(city);
            return new JsonResult(listOfCities);

        }

        [HttpDelete("{cityId}")]
        public IActionResult DeleteCity(int cityId)
        {
            var cityToDelete = _source.GetCityById(cityId);
            var listOfCities = _source.Cities;
            listOfCities.Remove(cityToDelete);
            return new JsonResult(listOfCities);

        }

        [HttpPut("{cityId}")]
        public IActionResult UpdateCity(int cityId, [FromBody] CityForUpdateDto cityToUpdate )
        {
            var cityUpdated = _source.GetCityById(cityId);
            if (cityUpdated == null) return NotFound();
            cityUpdated.Name = cityToUpdate.Name;
            cityUpdated.Description = cityToUpdate.Description;
            return Ok(cityUpdated);
        }

        private int GenerateCityId()
        {
            var listOfCities = _source.Cities;
            var lastCity = listOfCities.Last();
            return lastCity.Id + 1;
        }
    }
}
