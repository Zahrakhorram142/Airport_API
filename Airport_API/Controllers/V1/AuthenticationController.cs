using Airport.Application.Contracts;
using Airport.Application.Dtos;
using Airport.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Airport_API.Controllers.V1;

public class AuthenticationController:BaseController
{
    private readonly IAutenticationService _authenticationService;
    public AuthenticationController(IAutenticationService authenticationService)
    {
        _authenticationService=authenticationService;
    }
    [Route("Login")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Login([FromBody] LoginDto dto,CancellationToken ct)
    {
        var result=await _authenticationService.Login(dto);
                
        return Ok(result);

    }
    [Route("Register")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Register([FromBody] RegisterDto dto,CancellationToken ct)
    {
        var result=await _authenticationService.Register(dto);
        return Ok(result);

    }
}
