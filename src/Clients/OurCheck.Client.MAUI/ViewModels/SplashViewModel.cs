using OurCheck.Client.MAUI.ViewModels.Base;
using OurCheck.Client.MAUI.Views.Pages;

namespace OurCheck.Client.MAUI.ViewModels;

public class SplashViewModel : BasePageViewModel
{
    protected override async Task PageAppearingAsync()
    {
        await base.PageAppearingAsync();
        
        await Task.Delay(2000);
        await Shell.Current.GoToAsync($"///{nameof(HomePage)}");
    }
}