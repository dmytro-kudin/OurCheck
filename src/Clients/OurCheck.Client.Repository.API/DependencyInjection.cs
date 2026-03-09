using Microsoft.Extensions.DependencyInjection;
using OurCheck.Client.Repository.Abstract.Repositories;
using OurCheck.Client.Repository.API.Repositories;

namespace OurCheck.Client.Repository.API;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IAppointmentRepository, AppointmentRepository>();
        
        return services;
    }
}