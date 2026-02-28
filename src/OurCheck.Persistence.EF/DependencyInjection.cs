using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OurCheck.Persistence.Abstract.Repositories;
using OurCheck.Persistence.EF.Db;
using OurCheck.Persistence.EF.Repositories;

namespace OurCheck.Persistence.EF;

public static class DependencyInjection
{
    public static void AddPersistenceServices(this IHostApplicationBuilder builder)
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