using CommunityToolkit.Maui;
using OurCheck.Client.MAUI.ViewModels;
using OurCheck.Client.MAUI.Views.Pages;

namespace OurCheck.Client.MAUI;

public static class ConfigureServices
{
    extension(IServiceCollection services)
    {
        public IServiceCollection RegisterPresentationModels()
        {
            services.AddTransient<SplashViewModel>();
            services.AddTransient<SplashPage>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<HomePage>();
            // services.AddTransientWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));

            return services;
        }
        //
        // public IServiceCollection RegisterPresentationServices()
        // {
        //     // services.AddSingleton<INavigationService, MauiNavigationService>();
        //
        //     return services;
        // }
        //
        // IServiceCollection AddTransientWithShellRoute<TPage, TViewModel>() where TPage : ContentPage
        //     where TViewModel : BasePageViewModel
        // {
        //     return services.AddTransientWithShellRoute<TPage, TViewModel>("AppShell.GetPageRoute<TPage>()");
        // }
    }
}