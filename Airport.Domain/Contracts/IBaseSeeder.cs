namespace Airport.Domain.Contracts;

public interface IBaseSeeder<T>
{
    IEnumerable<T> GetSeedData();
}
