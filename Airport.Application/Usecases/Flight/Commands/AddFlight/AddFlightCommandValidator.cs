using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.Usecases.Flight.Commands;

public class AddFlightCommandValidator:AbstractValidator<AddFlightCommand>
{
    AddFlightCommandValidator()
    {
        RuleFor(x => x.Origin)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please enter valid name");
    }
}
