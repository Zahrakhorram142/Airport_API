using Airport.Application.Contracts;
using Airport.Domain.Contracts;
using Airport.Domain.Entities;
using Airport.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Infrastructure.Persistance.Repositories;

public class FlightService:IFlightService
{
    private readonly ApplicationDbContext _context;
    public FlightService(ApplicationDbContext context) => _context = context;


    public async Task<List<Flight>> GetFlights()
    {
        var flights = await _context.Flights.AsNoTracking().ToListAsync();
        return flights;
    }

    public async Task<Flight> GetFlightByIdAsync(int id)
    {

        var flight = await _context.Flights.Where(x => x.Id == id).FirstOrDefaultAsync();
        return flight;


    }

    public bool AddFlight(Flight flight)
    {
        _context.Flights.Add(flight);
        return _context.SaveChanges()>0;
    }
    public bool Activate(int flightId) 
    {
        var flight = _context.Flights.Where(x=>x.Id== flightId).FirstOrDefault();
        if (flight is null)
            return false;

        _context.SaveChanges();

        return true;
    }
}

