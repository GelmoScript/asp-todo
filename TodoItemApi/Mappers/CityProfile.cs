using System;
using AutoMapper;
using TodoItemApi.Dtos;
using TodoItemApi.Entities;

namespace TodoItemApi.Mappers
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>()
                .ReverseMap();
        }
    }
}
