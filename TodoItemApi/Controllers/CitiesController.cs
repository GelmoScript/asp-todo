using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoItemApi.Dtos;
using TodoItemApi.Services;
using TodoItemApi.Services.Repositories;
using AutoMapper;
using TodoItemApi.Entities;
using FluentValidation;

namespace TodoItemApi.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CityDto> _validator;

        public CitiesController(ICityRepository cityRepository, IMapper mapper, IValidator<CityDto> validator)
        {
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _cityRepository.GetCities();
            var cityDtos = _mapper.Map<IEnumerable<CityDto>>(cities);
            return Ok(cityDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            var city = _cityRepository.GetCityById(id);
            if (city is null)
                return NotFound();
            var cityDto = _mapper.Map<CityDto>(city);
            return Ok(cityDto);
        }

        [HttpGet("{id}/interests")]
        public IActionResult GetCityPointsOfInterest(int id)
        {
            var pointsOfInterest = _cityRepository.GetPointsOfInterestFromCityId(id);
            var pointOfInterestDtos = _mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterest);
            return Ok(pointOfInterestDtos);
        }

        [HttpPost]
        public IActionResult PostCity(CityDto cityDto)
        {
            var validationResult = _validator.Validate(cityDto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var city = _mapper.Map<City>(cityDto);
            _cityRepository.Create(city);
            return Created("", city);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var city = _cityRepository.GetCityById(id);
            if (city is null)
                return NotFound();
            var cityDeleted = _cityRepository.Delete(id);
            var cityDto = _mapper.Map<City>(cityDeleted);
            return Ok(cityDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] CityDto cityDto)
        {
            var city = _cityRepository.GetCityById(id);
            if (city is null)
                return NotFound();
            _mapper.Map(cityDto, city);
            var cityUpdated = _cityRepository.Update(city);
            return Ok(cityUpdated);
        }
    }
}
