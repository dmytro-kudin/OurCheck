using OurCheck.Dto.Common;

namespace OurCheck.Client.Repository.Abstract.Repositories;

public interface IRepositoryBase<TReturn, TCreate>
{
    Task<IEnumerable<TReturn>> GetAllAsync();
    Task<TReturn?> GetByIdAsync(Guid id);
    Task<CreatedDto> AddAsync(TCreate entity);
    Task UpdateAsync(TCreate entity, Guid id);
    Task DeleteAsync(Guid id);
}