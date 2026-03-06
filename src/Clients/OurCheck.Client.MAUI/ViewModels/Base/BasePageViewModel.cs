using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OurCheck.Client.MAUI.ViewModels.Base;

public abstract partial class BasePageViewModel : ObservableObject
{
    [RelayCommand]
    protected virtual async Task PageAppearing()
    {
        await Task.CompletedTask;
    }

    [RelayCommand]
    protected virtual async Task PageDisappearing()
    {
        await Task.CompletedTask;
    }
}