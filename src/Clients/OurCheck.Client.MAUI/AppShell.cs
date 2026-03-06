using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using OurCheck.Client.MAUI.Views.Pages;

namespace OurCheck.Client.MAUI;

public class AppShell : Shell
{
    public AppShell()
    {
        Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.NavigationPage.SetPrefersLargeTitles(this, true);
        BackgroundColor = Color.FromRgba(0, 0, 0, 0);
        FlyoutBehavior = FlyoutBehavior.Disabled;
        Items.Add(new ShellContent
        {
            Route = nameof(SplashPage),
            ContentTemplate = new DataTemplate(typeof(SplashPage))
        });
        Items.Add(new ShellContent
        {
            Route = nameof(HomePage),
            ContentTemplate = new DataTemplate(typeof(HomePage))
        });
    }
}