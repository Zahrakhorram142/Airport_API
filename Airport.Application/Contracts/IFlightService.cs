using Airport.Domain.Entities;
namespace Airport.Application.Contracts;

public interface IFlightService
{
    Task<List<Flight>> GetFlights();
    Task<Flight> GetFlightByIdAsync(int id);
    bool AddFlight(Flight flight);
}
