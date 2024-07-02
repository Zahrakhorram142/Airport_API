using Airport.Application.Wrappers;
using Airport.Domain.Contracts;
using Airport.Domain.Entities;

namespace Airport.Application.Contracts;

public interface IFlightService : IGenericRepository<Flight>
{
}
