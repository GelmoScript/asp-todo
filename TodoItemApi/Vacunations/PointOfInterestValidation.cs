using System;
using FluentValidation;
using TodoItemApi.Dtos;


namespace TodoItemApi.Vacunations
{
    public class PointOfInterestValidation : AbstractValidator<PointOfInterestDto>
    {
        public PointOfInterestValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("This field is required");
        }
    }
}
