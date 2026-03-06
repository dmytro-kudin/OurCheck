using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;
using OurCheck.Client.MAUI.Setup;

namespace OurCheck.Client.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup();

        builder.Services
            .RegisterConfiguration()
            .RegisterSerilog()
            .RegisterPresentationModels();
            // .AddCoreServices()
            // .RegisterPresentationModels()
            // .RegisterPresentationServices()
            // .RegisterInfrastructureServices()
            // .RegisterPostgreSqlPortServices()
            // .RegisterRoutes();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}