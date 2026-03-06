namespace OurCheck.Client.MAUI;

public class AppShell : Shell
{
    public AppShell()
    {
        FlyoutBehavior = FlyoutBehavior.Disabled;
        Items.Add(new ShellContent
            {
                Title = "Main",
                Route = nameof(MainPage),
                ContentTemplate = new DataTemplate(() => new MainPage())
            });
    }
}