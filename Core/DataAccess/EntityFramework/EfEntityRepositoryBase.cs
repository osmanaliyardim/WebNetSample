using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebNetSample.Core.Entities;

namespace WebNetSample.Core.DataAccess.EntityFramework;

public abstract class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
     where TEntity : BaseEntity
     where TContext : DbContext
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

        await DbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Expression<Func<TEntity, bool>> filter)
    {
        _dbSet.RemoveRange(_dbSet.Where(filter));

        await DbContext.SaveChangesAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        var query = _dbSet.Where(filter);

        var item = await query.SingleOrDefaultAsync();

        return item;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null) =>
            filter == null ? await _dbSet.ToListAsync() : await _dbSet.Where(filter).ToListAsync();

    public async Task UpdateAsync(TEntity entity)
    {
        DetachLocal(DbContext, entity, entity.Id);

        _dbSet.Update(entity);

        DbContext.Entry(entity).State = EntityState.Modified;

        await DbContext.SaveChangesAsync();
    }

    public void DetachLocal<Entity>(DbContext context, Entity entity, Guid entryId)
    where Entity : BaseEntity
    {
        var local = context.Set<Entity>()
            .Local
            .FirstOrDefault(entry => entry.Id.Equals(entryId));

        if (local != null)
        {
            context.Entry(local).State = EntityState.Detached;
        }

        context.Entry(entity).State = EntityState.Modified;
    }
}