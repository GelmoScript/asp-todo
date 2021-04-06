using System;
using TodoItemApi.Dtos;
using TodoItemApi.Entities;
using AutoMapper;

namespace TodoItemApi.Mappers
{
    public class PointOfInterestProfile : Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<PointOfInterest, PointOfInterestDto>()
                .ReverseMap();
        }
    }
}
