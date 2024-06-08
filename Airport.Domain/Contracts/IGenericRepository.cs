using System.Linq.Expressions;

namespace Airport.Domain.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IList<TEntity>> GetAllAsync(CancellationToken ct);
    Task<IList<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> condition, CancellationToken ct);
    Task<bool>AddAsync(TEntity entity, CancellationToken ct);
    Task<bool>UpdateAsync(TEntity entity, CancellationToken ct);
    Task<bool>DeleteAsync(TEntity entity, CancellationToken ct);
}
