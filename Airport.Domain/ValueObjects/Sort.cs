#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport.Domain.ValueObjects;

[NotMapped]
public class Sort
{
    public string PropertyName { get; set; }
    public bool IsAscending { get; set; }
}
