using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
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
        var cacheProvider = builder.Configuration["CacheProvider"];
        if (cacheProvider == "Redis")
            builder.AddRedis();
        else
            builder.AddMemoryCache();
    }

    private static void AddMemoryCache(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache(setup =>
        {
            setup.SizeLimit = 10000;
        });
        builder.Services.AddTransient<ICache, MemoryCache>();
    }

    private static void AddRedis(this IHostApplicationBuilder builder)
    {
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
            options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions
            {
                AbortOnConnectFail = true,
                EndPoints = { options.Configuration! }
            };
        });
        builder.Services.AddTransient<ICache, DistributedCache>();
    }
}