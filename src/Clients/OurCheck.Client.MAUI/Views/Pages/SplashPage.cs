using CommunityToolkit.Maui.Markup;
using OurCheck.Client.MAUI.ViewModels;
using OurCheck.Client.MAUI.Views.Pages.Base;

namespace OurCheck.Client.MAUI.Views.Pages;

public class SplashPage : BaseContentPage<SplashViewModel>
{
    public SplashPage(SplashViewModel viewModel) : base(viewModel)
    {
        Shell.SetNavBarIsVisible(this, false);
        
        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Children = 
            {
                new ActivityIndicator
                    {
                        IsRunning = true,
                    }
                    .Center()
            }
        }.Center();
    }
}