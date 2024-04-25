#nullable disable
namespace Airport.Application.Dtos;

public class FlightDto
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
}
