using System;
using System.Text.Json.Serialization;

namespace TodoItemApi.Models
{
    public class PointOfInterestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public int IdCity { get; set; }
        //public CityDto City {
        //    get
        //    {
        //        return ListDataSource.Instance.GetCityById(IdCity);
        //    }
        //}
    }
}
