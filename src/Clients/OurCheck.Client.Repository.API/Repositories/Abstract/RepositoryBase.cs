using System.Text;
using System.Text.Json;

namespace OurCheck.Client.Repository.API.Repositories.Abstract;

public abstract class RepositoryBase(HttpClient httpClient)
{
    private readonly JsonSerializerOptions _serializerOptions = new() { PropertyNameCaseInsensitive = true };

    protected async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(jsonResponse, _serializerOptions);
    }

    protected async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        var jsonRequest = JsonSerializer.Serialize(data);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(endpoint, content);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(jsonResponse, _serializerOptions)!;
    }

    protected async Task PutAsync<TRequest>(string endpoint, TRequest data)
    {
        var jsonRequest = JsonSerializer.Serialize(data);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        
        var response = await httpClient.PutAsync(endpoint, content);
        response.EnsureSuccessStatusCode();
    }

    protected async Task DeleteAsync(string endpoint)
    {
        var response = await httpClient.DeleteAsync(endpoint);
        response.EnsureSuccessStatusCode();
    }
}