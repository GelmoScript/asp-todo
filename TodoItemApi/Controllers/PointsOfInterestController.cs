using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TodoItemApi.Contexts;
using TodoItemApi.Dtos;
using TodoItemApi.Entities;
using TodoItemApi.Services;
using TodoItemApi.Services.Repositories;

namespace TodoItemApi.Controllers
{
    [ApiController]
    [Route("api/interests")]
    public class PointsOfInterestController : ControllerBase
    {

        private readonly IPointsOfInterestRepository _interestsRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PointOfInterestDto> _validator;

        public PointsOfInterestController(IPointsOfInterestRepository interestsRepository, IMapper mapper, IValidator<PointOfInterestDto> validator)
        {
            _interestsRepository = interestsRepository;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetPointOfInterests()
        {
            var interests = _interestsRepository.GetPointsOfInterest();
            var interestDto = _mapper.Map<IEnumerable<PointOfInterest>>(interests);
            return Ok(interestDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetPointOfInterestById(int id)
        {
            var interest = _interestsRepository.GetPointOfInterestById(id);
            if (interest is null)
                return NotFound();
            var interestDto = _mapper.Map<PointOfInterestDto>(interest);
            return Ok(interestDto);
        }

        [HttpPost]
        public IActionResult PostPointOfInterest([FromBody] PointOfInterestDto interestDto)
        {
            var validationResult = _validator.Validate(interestDto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var interest = _mapper.Map<PointOfInterest>(interestDto);
            var interestCreated = _interestsRepository.Create(interest);
            return Created("", interestCreated);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePointOfInterest(int id, [FromBody] PointOfInterestDto interestDto)
        {
            var interest = _interestsRepository.GetPointOfInterestById(id);
            if (interest is null)
                return NotFound();
            _mapper.Map(interestDto, interest);
            var interestUpdated = _interestsRepository.Update(interest);
            return Ok(interestUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePointOfInterest(int id)
        {
            var interest = _interestsRepository.GetPointOfInterestById(id);
            if (interest is null)
                return NotFound();
            var interestDeleted = _interestsRepository.Delete(id);
            var cityDto = _mapper.Map<PointOfInterest>(interestDeleted);
            return Ok(cityDto);
        }

    }
}
