using System;
using System.Collections.Generic;

namespace TodoItemApi.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; }
            = new List<PointOfInterestDto>();

        public int NumberOfPointOfInterests
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }

    }
}
