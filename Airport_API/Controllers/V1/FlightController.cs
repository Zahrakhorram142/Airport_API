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
using Airport.Application.Wrappers;


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
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var flights=await _FlightService.GetAllAsync(ct);
        return Ok(flights);
    }

    [Route("{id}")]
    [HttpGet]
    public async Task <IActionResult> Get([FromRoute] int id, CancellationToken ct)
    {
        
       var flight = await _FlightService.FindByCondition(x=>x.Id== id,ct);

       if (flight is null)
         return NotFound();


       var flightDto=_mapper.Map<FlightDto>(flight);

        return Ok(flightDto);
    }

    [Route("")]
    [HttpDelete]
    public async Task <bool> Delete(CancellationToken ct)
    {
        return true;
    }

    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Add([FromBody] AddFlightDto flightDto, CancellationToken ct)
    {
       
       var flight=_mapper.Map<Flight>(flightDto);
        _FlightService.AddAsync(flight,ct);

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
        //var isActivate=_FlightService.Activate(flightId);
        return true;
        
    }

}
