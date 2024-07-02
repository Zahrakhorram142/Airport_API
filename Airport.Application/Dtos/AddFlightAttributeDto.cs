using Airport.Domain.Entities;
using FluentValidation;

namespace Airport.Application.Dtos;

public record AddFlightAttributeDto(int flightId,string Key,string Value);

public class AddFlightAttributeDtoValidator:AbstractValidator<FlightAttribute>
{
    public AddFlightAttributeDtoValidator()
    {
        RuleFor(x => x.Key)
          .NotEmpty()
          .NotNull()
          .MinimumLength(2)
          .WithMessage("Please enter valid key");
        RuleFor(x => x.Value)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please enter valid value");

    }
}