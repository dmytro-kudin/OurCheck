using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using OurCheck.Client.MAUI.ViewModels.Base;

namespace OurCheck.Client.MAUI.Views.Pages.Base;

public abstract class BaseContentPage<T> : ContentPage where T : BasePageViewModel
{
    protected BaseContentPage(T viewModel)
    {
        base.BindingContext = viewModel;
        
        SafeAreaEdges = SafeArea;
        
        On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
        On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
        
        Shell.SetBackgroundColor(this, Colors.Transparent);
        Shell.SetNavBarHasShadow(this, false);
        
        InitView();
    }

    protected new T BindingContext => (T)base.BindingContext;
    
    protected virtual SafeAreaEdges SafeArea => SafeAreaEdges.All;

    protected virtual void InitView()
    {
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();

        BindingContext.PageAppearingCommand.ExecuteAsync(null);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        BindingContext.PageDisappearingCommand.ExecuteAsync(null);
    }
}