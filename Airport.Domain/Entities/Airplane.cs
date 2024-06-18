using Airport.Domain.Contracts;

namespace Airport.Domain.Entities;
[Entity]
public class Airplane : BaseEntity<short>
{
    public string Model { get; set; }
    public int Capacity { get; set; }
    public int YearOfConstruction { get; set; }
    public string Manufacturer { get; set; }
}
