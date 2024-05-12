using Airport.Domain.Contracts;

namespace Airport.Domain.Entities;
public class Flight: BaseEntity<int>
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string Day { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool IsActivate { get; private set; }
    public string MetaDescription { get; set; }

    public void Activate() => IsActivate = true;
    public void Deactivate() => IsActivate = false;

    public ICollection<FlightAttribute> FlightAttributes { get; set; }

}

