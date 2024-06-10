using Airport.Domain.Contracts;
using Airport.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airport.Infrastructure.Persistance.Repositories;

public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _dbContext;

    protected GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(TEntity entity, CancellationToken ct)
    {
        //First Way
        //_dbContext.Add(entity);

        //Second way
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> UpdateAsync(TEntity entity, CancellationToken ct)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(TEntity entity, CancellationToken ct)
    {

        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(ct);
        return true;
    }

    public async Task<IList<TEntity>> GetAllAsync(CancellationToken ct)
    {
        return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<IList<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct)
    {
        return await _dbContext.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync();
    }

}

