using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace OurCheck.Infrastructure.Data;

public static class ApplicationDbContextInitialiser
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        await using var serviceScope = app.Services.CreateAsyncScope();
        await using var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        await dbContext.Database.EnsureCreatedAsync();
    }
}