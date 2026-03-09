using OurCheck.Client.Repository.Abstract.Repositories;
using OurCheck.Dto.Common;

namespace OurCheck.Client.Repository.API.Repositories.Abstract;

public abstract class RepositoryBase<TReturn, TCreate>(HttpClient httpClient) : RepositoryBase(httpClient), IRepositoryBase<TReturn, TCreate>
{
    protected abstract string FeaturePath { get; }
    
    public virtual async Task<IEnumerable<TReturn>> GetAllAsync()
    {
        var result = await GetAsync<IEnumerable<TReturn>?>(FeaturePath);
        return result!;
    }

    public virtual Task<TReturn?> GetByIdAsync(Guid id)
    {
        return GetAsync<TReturn>($"{FeaturePath}/{id}");
    }

    public virtual Task<CreatedDto> AddAsync(TCreate entity)
    {
        return PostAsync<TCreate, CreatedDto>(FeaturePath, entity);
    }

    public virtual Task UpdateAsync(TCreate entity, Guid id)
    {
        return PutAsync($"{FeaturePath}/{id}", entity);
    }

    public virtual Task DeleteAsync(Guid id)
    {
        return DeleteAsync($"{FeaturePath}/{id}");
    }
}