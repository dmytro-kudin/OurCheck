namespace OurCheck.Application.Services.Cache;

public interface ICache
{
    Task SetSingleAsync<T>(string key, T value);
    
    Task SetListAsync<T>(string key, T value);
    
    Task<bool> TryGetValueAsync<T>(string key, out T? value);
    
    Task RemoveAsync(string key);
    
    Task ClearAsync();

    Task RemoveByTagAsync(string tag);
    
    ValueTask<T?> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, ValueTask<T?>> factory,
        IEnumerable<string>? tags = null,
        CancellationToken cancellationToken = default);
}