#nullable disable
using Airport.Domain.Contracts;

namespace Airport.Domain.Entities;

public class FlightCategory:BaseEntity<int>
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
