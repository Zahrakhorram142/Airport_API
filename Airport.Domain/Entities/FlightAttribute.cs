using Airport.Domain.Contracts;

namespace Airport.Domain.Entities;

[Entity]
public class FlightAttribute:BaseEntity<int>
{
    public string Key { get; set; }
    public string Value { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
}
