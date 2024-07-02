#nullable disable
namespace Airport.Domain.Contracts
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public int Code { get; set; }

    }

}
