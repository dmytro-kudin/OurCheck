using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OurCheck.Application.Repositories;

namespace OurCheck.Repositories;

public static class DependencyInjection
{
    public static void AddRepositories(this IHostApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
        builder.Services.AddTransient<ISavedPlaceRepository, SavedPlaceRepository>();
    }
}