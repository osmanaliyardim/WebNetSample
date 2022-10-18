using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebNetSample.Core.Entities;

namespace WebNetSample.Core.DataAccess.EntityFramework;

public abstract class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
     where TEntity : BaseEntity, new()
     where TContext : DbContext, new()
{
    protected readonly TContext DbContext;

    private readonly DbSet<TEntity> _dbSet;

    protected EfEntityRepositoryBase(TContext dbContext)
    {
        DbContext = dbContext;
        _dbSet = DbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Delete(Expression<Func<TEntity, bool>> filter)
    {
        _dbSet.RemoveRange(_dbSet.Where(filter));
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        var query = _dbSet.Where(filter);

        var item = await query.SingleOrDefaultAsync();

        return item;
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null) =>
            filter == null ? await _dbSet.ToListAsync() : await _dbSet.Where(filter).ToListAsync();

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

}