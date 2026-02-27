using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OurCheck.Application.Repositories;
using OurCheck.Infrastructure.Data;

namespace OurCheck.Persistence;

public static class DependencyInjection
{
    public static void AddRepositories(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString);
        });
        
        builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
        builder.Services.AddTransient<ISavedPlaceRepository, SavedPlaceRepository>();
    }
}