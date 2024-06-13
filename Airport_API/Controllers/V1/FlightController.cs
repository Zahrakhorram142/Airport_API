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
using Microsoft.Identity.Client;
using Airport.Application.Usecases.Flight.Commands;
using Airport.Domain.ValueObjects;
using Airport.Infrastructure.Persistance.Repositories;


namespace Airport_API.Controllers.V1;



public class FlightController : BaseController
{
    private readonly IFlightService _flightService;
    private readonly IMapper _mapper;
    private readonly MySettings _mysettings;
    public FlightController(IFlightService flightService,IMapper mapper,IOptionsSnapshot<MySettings>mySettings) 
    {
        _mysettings = mySettings.Value;
        _mapper = mapper;
        _flightService = flightService;
    }

    [Route("{GetAll}")]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromBody]QueryCriteria queryCriteria = null,CancellationToken ct=default)
    {
        var flights = await _flightService.GetAllAsync(ct);
        return Ok(flights);
    }

    [Route("{id}")]
    [HttpGet]
    public async Task <IActionResult> Get([FromRoute] int id, CancellationToken ct)
    {
        
       var flight = await _flightService.FindByCondition(x=>x.Id== id,ct);

       if (flight is null)
         return NotFound();


       var flightDto=_mapper.Map<FlightDto>(flight);

        return Ok(flightDto);
    }

    [Route("Delete")]
    [HttpDelete]
    public async Task <bool> Delete(CancellationToken ct)
    {
        return true;
    }

    [Route("Add")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Add([FromBody] AddFlightCommand command, CancellationToken ct)
       =>await SendAsync(command, ct);

    
    [Route("Update")]
    [HttpPut]
    public async Task< bool> Update(Flight flight)
    {
        return true;
    }
    [Route("Activate")]
    [HttpPut]
    public bool Activate([FromRoute] int flightId)
    {
        //var isActivate=_FlightService.Activate(flightId);
        return true;
        
    }

}
