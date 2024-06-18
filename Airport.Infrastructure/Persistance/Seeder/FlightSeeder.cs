using Airport.Domain.Contracts;
using Airport.Domain.Entities;


namespace Airport.Infrastructure.Persistance.Seeder;

public class FlightSeeder:IBaseSeeder<Flight>
{
    public IEnumerable<Flight> GetSeedData()
        => new List<Flight>()
    {
                    new ()
                    {
                      Origin="Tehran",
                      Destination="Mashhad",
                      Code=3,
                      Price=1,
                      Day="Sunday",
                    }
                };
}
