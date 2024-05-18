using Airport.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.Contracts;

public interface IAutenticationService
{
   Task<AuthenticationResponseDto> Login(LoginDto dto);
    Task<AuthenticationResponseDto> Register(RegisterDto dto);
}
