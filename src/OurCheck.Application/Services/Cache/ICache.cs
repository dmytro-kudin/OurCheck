namespace OurCheck.Application.Services.Cache;

public interface ICache
{
    Task SetSingleAsync<T>(string key, T value, IEnumerable<string>? tags = null);
    
    Task SetListAsync<T>(string key, T value, IEnumerable<string>? tags = null);
    
    Task RemoveAsync(string key);

    Task RemoveByTagAsync(string tag);
    
    ValueTask<T?> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, ValueTask<T?>> factory,
        IEnumerable<string>? tags = null,
        CancellationToken cancellationToken = default);
}