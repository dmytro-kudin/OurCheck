using System.Collections;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace OurCheck.Application.Services.Cache;

public class MemoryCache(
    IMemoryCache cache,
    ILogger<MemoryCache> logger) : ICache
{
    public Task SetSingleAsync<T>(string key, T value)
    {
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(30))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
            .SetPriority(CacheItemPriority.Normal);
        return SetAsync(key, value, cacheOptions);
    }

    public Task SetListAsync<T>(string key, T value)
    {
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(30))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
            .SetPriority(CacheItemPriority.NeverRemove)
            .SetSize(2048);
        return SetAsync(key, value, cacheOptions);
    }

    public Task<bool> TryGetValueAsync<T>(string key, out T? value)
    {
        logger.LogDebug("fetching data for key: {CacheKey} from cache.", key);
        var result = cache.TryGetValue(key, out T? cachedValue);
        value = cachedValue;

        if (result)
            logger.LogDebug("cache hit for key: {CacheKey}.", key);
        else
            logger.LogDebug("cache miss. fetching data for key: {CacheKey} from database.", key);

        return Task.FromResult(result);
    }

    public Task RemoveAsync(string key)
    {
        logger.LogDebug("invalidating cache for key: {CacheKey} from cache.", key);
        cache.Remove(key);
        
        return Task.CompletedTask;
    }

    public Task ClearAsync()
    {
        if (cache is Microsoft.Extensions.Caching.Memory.MemoryCache memoryCache)
        {
            logger.LogDebug("clearing cache.");
            memoryCache.Clear();
        }
        
        return Task.CompletedTask;
    }

    public Task RemoveByTagAsync(string tag)
    {
        return ClearAsync();
    }

    public async ValueTask<T?> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, ValueTask<T?>> factory,
        IEnumerable<string>? tags = null,
        CancellationToken cancellationToken = default)
    {
        if (await TryGetValueAsync(key, out T? cachedValue))
            return cachedValue;

        var newValue = await factory(cancellationToken);
        if (newValue is null)
            return default;

        if (newValue is IList)
            await SetListAsync(key, newValue);
        else
            await SetSingleAsync(key, newValue);

        return newValue;
    }

    private Task SetAsync<T>(string key, T value, MemoryCacheEntryOptions cacheOptions)
    {
        logger.LogDebug("setting data for key: {CacheKey} to cache.", key);
        cache.Set(key, value, cacheOptions);
        
        return Task.CompletedTask;
    }
}