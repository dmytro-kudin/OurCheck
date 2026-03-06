using OurCheck.Client.MAUI.Views.Pages;

namespace OurCheck.Client.MAUI;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Shell.Current.GoToAsync(nameof(HomePage));
        });
    }
}