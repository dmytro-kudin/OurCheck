using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OurCheck.Application.Common.Interfaces;
using OurCheck.Infrastructure.Data;

namespace OurCheck.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString);
        });
        builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
    }
}