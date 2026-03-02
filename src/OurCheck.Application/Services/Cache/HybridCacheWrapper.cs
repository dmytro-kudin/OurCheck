using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;

namespace OurCheck.Application.Services.Cache;

public class HybridCacheWrapper(
    HybridCache cache,
    ILogger<HybridCacheWrapper> logger) : ICache
{
    public async Task SetSingleAsync<T>(string key, T value, IEnumerable<string>? tags = null)
    {
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(5),
            LocalCacheExpiration = TimeSpan.FromSeconds(30)
        };
        await SetAsync(key, value, entryOptions, tags);
    }

    public async Task SetListAsync<T>(string key, T value, IEnumerable<string>? tags = null)
    {
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(5),
            LocalCacheExpiration = TimeSpan.FromSeconds(30)
        };
        await SetAsync(key, value, entryOptions, tags);
    }

    public async Task RemoveAsync(string key)
    {
        logger.LogDebug("invalidating cache for key: {CacheKey} from cache.", key);
        await cache.RemoveAsync(key);
    }

    public async Task RemoveByTagAsync(string tag)
    {
        logger.LogDebug("invalidating cache by tag: {CacheTag} from cache.", tag);
        await cache.RemoveByTagAsync(tag);
    }

    public ValueTask<T?> GetOrCreateAsync<T>(string key, Func<CancellationToken, ValueTask<T?>> factory, IEnumerable<string>? tags = null,
        CancellationToken cancellationToken = default)
    {
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(5),
            LocalCacheExpiration = TimeSpan.FromSeconds(30)
        };
        logger.LogDebug("get or create data for key: {CacheKey} and tags: {CacheTags} to cache.", key, tags);
        return cache.GetOrCreateAsync(key, factory, entryOptions, tags, cancellationToken);
    }

    private async Task SetAsync<T>(string key, T value, HybridCacheEntryOptions cacheOptions, IEnumerable<string>? tags)
    {
        logger.LogDebug("setting data for key: {CacheKey} to cache.", key);
        await cache.SetAsync(key, value, cacheOptions, tags);
    }
}