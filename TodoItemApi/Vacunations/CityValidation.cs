using System;
using FluentValidation;
using TodoItemApi.Dtos;

namespace TodoItemApi.Vacunations
{
    public class CityValidation : AbstractValidator<CityDto>
    {
        public CityValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("This field is required");
        }
    }
}
