using Microsoft.EntityFrameworkCore;
using OurCheck.Domain.Entities;
using OurCheck.Persistence.Abstract.Repositories;
using OurCheck.Persistence.EF.Db;

namespace OurCheck.Persistence.EF.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
{
    protected AppDbContext Context { get; }
    protected DbSet<T> DbSet { get; }

    public RepositoryBase(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await DbSet.AsNoTracking().ToListAsync();
    public virtual async Task<T?> GetByIdAsync(Guid id) => await DbSet.FindAsync(id);

    public virtual async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}