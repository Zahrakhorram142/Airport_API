#nullable disable

using Airport.Application.Wrappers;
using MediatR;

namespace Airport.Application.Usecases.Flight.Commands;

public record AddFlightCommand : IRequest<Response<int>>
{
    public string Origin { get; set; }
    public string Destination { get; set; }
}
