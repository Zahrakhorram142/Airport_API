using FluentValidation;

namespace Airport.Application.Dtos;

public class AddFlightDto
{
    public string Origin { get; set; }
    public string Destination { get; set; }
}
public class AddProductDtoValidator : AbstractValidator<AddFlightDto>
{
    public AddProductDtoValidator()
    {
        RuleFor(x => x.Origin)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please enter valid origin");
        RuleFor(x=>x.Destination)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please enter valid Destination");

    }

}
