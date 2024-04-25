using Airport.Application.Dtos;
using Airport.Domain.Entities;
using AutoMapper;

namespace Airport.Application.Profiles;

public class FlightProfile : Profile
{
    protected FlightProfile()
    {
        //Source,Dest
        CreateMap<AddFlightDto, Flight>();
        CreateMap<Flight, FlightDto>();
    }
}
