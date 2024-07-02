using Airport.Domain.Entities;

namespace Airport.Application.Contracts;

public interface IFlightAttributeService
{
    bool AddFlightAttribute(FlightAttribute flightAttribute);
}
