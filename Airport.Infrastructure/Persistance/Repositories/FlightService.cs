using Airport.Application.Contracts;
using Airport.Application.Exceptions;
using Airport.Application.Wrappers;
using Airport.Infrastructure.Context;


namespace Airport.Infrastructure.Persistance.Repositories;

public class FlightService:GenericRepository<Domain.Entities.Flight>,IFlightService
{
    private readonly ApplicationDbContext _context;
    public FlightService(ApplicationDbContext context) : base(context)
    {

    }


      public Response< bool> Activate(int flightId) 
    {
        var flight = _context.Flights.Where(x=>x.Id== flightId).FirstOrDefault();
        if (flight is null)
            throw new ApiException($"Flight Not Found.");
        flight.Activate();

        _context.SaveChanges();

        return new Response<bool>(true);
    }
}

