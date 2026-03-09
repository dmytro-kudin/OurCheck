using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;
using OurCheck.Client.Application;
using OurCheck.Client.MAUI.Setup;
using OurCheck.Client.Repository.API;

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

        var httpClient = new HttpClient {BaseAddress = new Uri("http://localhost:5017/")};
        builder.Services.AddSingleton(httpClient);

        builder.Services
            .RegisterConfiguration()
            .RegisterSerilog()
            .RegisterPresentationModels()
            .AddRepositories()
            .AddServices();
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