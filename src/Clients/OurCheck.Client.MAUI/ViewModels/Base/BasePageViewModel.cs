using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OurCheck.Client.MAUI.ViewModels.Base;

public abstract partial class BasePageViewModel : ObservableObject
{
    private bool _initialized = false;

    [ObservableProperty]
    public bool _isRefreshing;

    public BasePageViewModel()
    {
        LoadDataCommand = new AsyncRelayCommand(InternalLoadDataAsync);
    }

    public IAsyncRelayCommand LoadDataCommand { get; }
    
    [RelayCommand]
    protected virtual async Task PageAppearingAsync()
    {
        if (!_initialized)
        {
            await LoadDataCommand.ExecuteAsync(null);
            _initialized = true;
        }
    }

    [RelayCommand]
    protected virtual async Task PageDisappearingAsync()
    {
        await Task.CompletedTask;
    }

    protected virtual async Task LoadDataAsync()
    {
        await Task.CompletedTask;
    }

    private async Task InternalLoadDataAsync()
    {
        try
        {
            IsRefreshing = true;
            await LoadDataAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }
}