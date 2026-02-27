using OurCheck.Domain.Entities;

namespace OurCheck.Application.Repositories;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}