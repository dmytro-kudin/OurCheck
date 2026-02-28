using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OurCheck.Application.Common.Behaviors;
using OurCheck.Application.Services.Cache;

namespace OurCheck.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(RequestResponseLoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        builder.AddCache();
    }

    private static void AddCache(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache(setup =>
        {
            setup.SizeLimit = 10000;
        });
        builder.Services.AddTransient<ICache, MemoryCache>();
    }
}