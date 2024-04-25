using Airport.Domain.Contracts;

namespace Airport.Domain.Entities;
public class Flight: BaseEntity<int>
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string Day { get; set; }
    public DateTime DateTime { get; set; }
}
