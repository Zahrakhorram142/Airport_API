#nullable disable
namespace Airport.Domain.Contracts;

public interface IAuditable
{
    public int UserId { get; set; }    
    public DateTime UpdateAt { get; set; }
}
