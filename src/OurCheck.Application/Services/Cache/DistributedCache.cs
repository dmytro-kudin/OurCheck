using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OurCheck.Application.Common.Extensions;
using StackExchange.Redis;

namespace OurCheck.Application.Services.Cache;

public class DistributedCache(
    IDistributedCache cache,
    ILogger<DistributedCache> logger,
    IConfiguration configuration) : ICache
{
    public async Task SetSingleAsync<T>(string key, T value)
    {
        logger.LogDebug("setting data for key: {CacheKey} to cache.", key);
        await cache.SetAsync(key, value);
    }

    public async Task SetListAsync<T>(string key, T value)
    {
        logger.LogDebug("setting data for key: {CacheKey} to cache.", key);
        await cache.SetAsync(key, value);
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

    public async Task RemoveAsync(string key)
    {
        logger.LogDebug("invalidating cache for key: {CacheKey} from cache.", key);
        await cache.RemoveAsync(key);
    }

    public async Task ClearAsync()
    {
        logger.LogDebug("clearing cache.");
        var connectionString = configuration.GetConnectionString("RedisConnection");
        await using var connection = await ConnectionMultiplexer.ConnectAsync($"{connectionString},allowAdmin=true");
        await connection.GetServer($"{connectionString}:6379").FlushDatabaseAsync();
    }
}