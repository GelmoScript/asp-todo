using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TodoItemApi.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; }
            = new List<PointOfInterestDto>();

        [JsonIgnore]
        public int NumberOfPointOfInterests
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }


            
        
    }
}
