using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OurCheck.Persistence.EF.Db;

public static class ApplicationDbContextInitialiser
{
    public static async Task InitialiseDatabaseAsync(this IHost app)
    {
        await using var serviceScope = app.Services.CreateAsyncScope();
        await using var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        await dbContext.Database.EnsureCreatedAsync();
    }
}