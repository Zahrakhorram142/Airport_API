#nullable disable

using Airport.Domain.Contracts;

namespace Airport.Domain.Entities;

public class Category:BaseEntity<int>
{
    public string Name {  get; set; }   
    public bool IsActivate { get; set; }
}
