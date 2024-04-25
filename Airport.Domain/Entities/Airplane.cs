using Airport.Domain.Contracts;

namespace Airport.Domain.Entities;

public class Airplane: BaseEntity<short>
{
    public string Name { get; set; }
}
