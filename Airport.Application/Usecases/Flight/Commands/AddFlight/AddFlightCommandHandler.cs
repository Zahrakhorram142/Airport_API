#nullable disable

using Airport.Application.Contracts;
using Airport.Application.Wrappers;
using Airport.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Airport.Application.Usecases.Flight.Commands;

public class AddFlightCommandHandler:IRequestHandler<AddFlightCommand,Response<int>>
{
    private readonly IFlightService _flightService;
    private readonly IMapper _mapper;

    public AddFlightCommandHandler(IFlightService flightService, IMapper mapper)
    {
        _flightService = flightService;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(AddFlightCommand request, CancellationToken ct)
    {
        var flight = _mapper.Map<Airport.Domain.Entities.Flight>(request);
        await _flightService.AddAsync(flight,ct);
        return new Response<int>();
    }
}
