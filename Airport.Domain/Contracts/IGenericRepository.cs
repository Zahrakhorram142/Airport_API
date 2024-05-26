using System.Linq.Expressions;

namespace Airport.Domain.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IList<TEntity>> GetAllAsync();
    Task<IList<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> condition);
    Task<bool>AddAsync(TEntity entity);
    Task<bool>UpdateAsync(TEntity entity);
    Task<bool>DeleteAsync(TEntity entity);
}
