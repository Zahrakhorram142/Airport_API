#nullable disable

using Airport.Domain.Contracts;

namespace Airport.Domain.Entities;
[Entity]
public class Category:BaseEntity<int>
{
    public string Name {  get; set; }   
    public bool IsActivate { get; set; }
}
