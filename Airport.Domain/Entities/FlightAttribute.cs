using Airport.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Entities;

public class FlightAttribute:BaseEntity<int>
{
    public string Key { get; set; }
    public string Value { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
}
