using Airport.Application.Dtos;

namespace Airport.Application.Contracts;

public interface IAutenticationService
{
   Task<AuthenticationResponseDto> Login(LoginDto dto);
    Task<AuthenticationResponseDto> Register(RegisterDto dto);
}
