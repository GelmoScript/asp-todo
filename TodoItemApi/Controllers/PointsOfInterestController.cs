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
    [Route("api/interests")]
    public class PointsOfInterestController : ControllerBase
    {

        private readonly IDataSource _source;

        public PointsOfInterestController(IDataSource source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }

        [HttpGet]
        public IActionResult GetPointOfInterests()
        {
            return new JsonResult(_source.PointOfInterests);
        }

        [HttpGet("{id}")]
        public IActionResult GetPointOfInterestById(int id)
        {
            PointOfInterestDto interest = _source.GetPointOfInterestById(id);

            if (interest == null) return NotFound("Not Point of interest with the given id, try another.");

            return Ok(interest);
        }

        [HttpPost]
        public IActionResult PostPointOfInterest([FromBody] PointOfInterestDto interestDto)
        {
            var listOfInterests = _source.PointOfInterests;
            int newInterestId = GeneratePointOfInterestId();
            interestDto.Id = newInterestId;
            listOfInterests.Add(interestDto);
            return new JsonResult(listOfInterests);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePointOfInterest(int id, [FromBody] PointOfInterestDto interestDto)
        {
            var interestToUpdate = _source.GetPointOfInterestById(id);
            if (interestToUpdate == null) return NotFound();

            if (interestDto.Name != null)
                interestToUpdate.Name = interestDto.Name;

            if (interestDto.Description != null)
                interestToUpdate.Description = interestDto.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePointOfInterest(int id)
        {
            var interestToDelete = _source.GetPointOfInterestById(id);
            if (interestToDelete == null) return NotFound("Not Point of interest with the biven id");
            var listOfInterests = _source.PointOfInterests;
            listOfInterests.Remove(interestToDelete);
            return Ok(listOfInterests);
        }

        private int GeneratePointOfInterestId()
        {
            var listOfInterests = _source.PointOfInterests;
            var lastInterest = listOfInterests.Last();
            return lastInterest.Id + 1;
        }
    }
}
