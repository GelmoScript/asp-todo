using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoItemApi.Models;


namespace TodoItemApi.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = ListDataSource.Instance.Cities;
            return new JsonResult(cities);
        }

        [HttpGet("{cityId}")]
        public IActionResult GetCityById(int cityId)
        {
            var city = ListDataSource.Instance.GetCityById(cityId);
            return new JsonResult(city);
        }

        [HttpGet("{cityId}/interests")]
        public IActionResult GetCityPointsOfInterest(int cityId)
        {
            var pointOfInterest = ListDataSource.Instance.GetPointOfInterestByCityId(cityId);
            return new JsonResult(pointOfInterest);
        }

        [HttpPost]
        public IActionResult PostCity(CityDto city)
        {
            var listOfCities = ListDataSource.Instance.Cities;
            int newCityId = GenerateCityId();
            city.Id = newCityId;
            listOfCities.Add(city);
            return new JsonResult(listOfCities);

        }

        [HttpDelete("{cityId}")]
        public IActionResult DeleteCity(int cityId)
        {
            var cityToDelete = ListDataSource.Instance.GetCityById(cityId);
            var listOfCities = ListDataSource.Instance.Cities;
            listOfCities.Remove(cityToDelete);
            return new JsonResult(listOfCities);

        }

        [HttpPut("{cityId}")]
        public IActionResult UpdateCity(int cityId, [FromBody] CityForUpdateDto cityToUpdate )
        {
            var cityUpdated = ListDataSource.Instance.GetCityById(cityId);
            if (cityUpdated == null) return NotFound();
            cityUpdated.Name = cityToUpdate.Name;
            cityUpdated.Description = cityToUpdate.Description;
            return Ok(cityUpdated);
        }

        private int GenerateCityId()
        {
            var listOfCities = ListDataSource.Instance.Cities;
            var lastCity = listOfCities.Last();
            return lastCity.Id + 1;
        }
    }
}
