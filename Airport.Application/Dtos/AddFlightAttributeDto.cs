using Airport.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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