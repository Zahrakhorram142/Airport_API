using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;
using AutoMapper;
using Airport_API.Shared.Configs;
using Microsoft.Extensions.Options;
using Airport.Domain.Entities;
using Airport.Application.Contracts;
using Airport.Application.Dtos;


namespace Airport_API.Controllers.V1;



public class FlightController : BaseController
{
    private readonly IFlightService _FlightService;
    private readonly IMapper _mapper;
    private readonly MySettings _mysettings;
    public FlightController(IFlightService flightService,IMapper mapper,IOptionsSnapshot<MySettings>mySettings) 
    {
        _mysettings = mySettings.Value;
        _mapper = mapper;
        _FlightService = flightService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Flight>flights=await _FlightService.GetFlights();
        return Ok(flights);
    }

    [Route("{id}")]
    [HttpGet]
    public async Task <IActionResult> Get([FromRoute] int Id)
    {
        
        Flight flight = await _FlightService.GetFlightByIdAsync(Id);

        if (flight is null)
            return NotFound();


       var flightDto=_mapper.Map<FlightDto>(flight);

        return Ok(flightDto);
    }

    [Route("")]
    [HttpDelete]
    public async Task <bool> Delete()
    {
        return true;
    }

    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Add([FromBody] AddFlightDto flightDto)
    {
       
       var flight=_mapper.Map<Flight>(flightDto);
        _FlightService.AddFlight(flight);

        return Created();

    }
    [Route("")]
    [HttpPut]
    public async Task< bool> Update(Flight flight)
    {
        return true;
    }
    public bool Activate([FromRoute] int flightId)
    {
        var isActivate=_FlightService.Activate(flightId);
        return isActivate;
        
    }

}
