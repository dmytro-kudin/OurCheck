namespace OurCheck.Application.Services.Cache;

public interface ICache
{
    Task SetSingleAsync<T>(string key, T value);
    
    Task SetListAsync<T>(string key, T value);
    
    Task<bool> TryGetValueAsync<T>(string key, out T? value);
    
    Task RemoveAsync(string key);
}