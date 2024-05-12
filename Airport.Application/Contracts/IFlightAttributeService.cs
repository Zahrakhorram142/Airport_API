using Airport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.Contracts;

public interface IFlightAttributeService
{
    bool AddFlightAttribute(FlightAttribute flightAttribute);
}
