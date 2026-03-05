using System.Reflection;
using Microsoft.Extensions.Configuration;
using OurCheck.Client.Application.Exceptions;

namespace OurCheck.Client.MAUI.Setup;

public static class ConfigurationSetup
{
    private const string AppSettingsFilePath = "OurCheck.Client.MAUI.appsettings.json";

    public static IServiceCollection RegisterConfiguration(this IServiceCollection services)
    {
        var generalConfigStream = Assembly.GetExecutingAssembly()
            .GetManifestResourceStream(AppSettingsFilePath);

        var configBuilder = new ConfigurationBuilder()
            .AddJsonStream(generalConfigStream ??
                           throw new InvalidConfigurationException("Unable to load configuration file"));

        IConfiguration configuration = configBuilder.Build();

        services.AddSingleton(configuration);

        return services;
    }
}