#nullable disable
namespace Airport.Domain.Contracts;

public interface IDeletable
{
    public int DeleteByUserId { get; set; }
    public DateTime DeletedAt { get; set; }
}
