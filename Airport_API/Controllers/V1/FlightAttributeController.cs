using Airport.Application.Contracts;
using Airport.Application.Dtos;
using Airport.Domain.Entities;
using Airport_API.Shared.Configs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;

namespace Airport_API.Controllers.V1;

public class FlightAttributeController:BaseController
{
    private readonly IFlightAttributeService _flightAttributeService;
    private readonly IMapper _mapper;
    public FlightAttributeController(IFlightAttributeService flightAttributeService, IMapper mapper)
    { 
        _mapper = mapper;
        _flightAttributeService = flightAttributeService;
    }
    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Add([FromBody] AddFlightDto dto)
    {

        var flightAttribute = _mapper.Map<FlightAttribute>(dto);
        _flightAttributeService.AddFlightAttribute(flightAttribute);

        return Created();

    }
}
