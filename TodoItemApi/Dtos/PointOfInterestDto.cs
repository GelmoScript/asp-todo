using System;
using System.Text.Json.Serialization;

namespace TodoItemApi.Dtos
{
    public class PointOfInterestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int IdCity { get; set; }
        public CityDto City { get; }

        public bool IsDeleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
