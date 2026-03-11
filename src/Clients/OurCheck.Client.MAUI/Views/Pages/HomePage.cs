using CommunityToolkit.Maui.Markup;
using OurCheck.Client.MAUI.ViewModels;
using OurCheck.Client.MAUI.Views.Cells;
using OurCheck.Client.MAUI.Views.Pages.Base;

namespace OurCheck.Client.MAUI.Views.Pages;

public class HomePage : BaseContentPage<HomeViewModel>
{
    public HomePage(HomeViewModel viewModel) : base(viewModel)
    {
    }
    
    protected override SafeAreaEdges SafeArea => SafeAreaEdges.None;

    protected override void InitView()
    {
        Title = "Home";

        Content = new RefreshView
            {
                Content = new CollectionView
                    {
                        SelectionMode = SelectionMode.None,
                        ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical),
                        ItemTemplate = new DataTemplate(() => new AppointmentCell())
                    }
                    .Bind(ItemsView.ItemsSourceProperty, static (HomeViewModel vm) => vm.Appointments)
            }
            .Bind(RefreshView.IsRefreshingProperty, static (HomeViewModel vm) => vm.IsRefreshing)
            .Bind(RefreshView.CommandProperty, static (HomeViewModel vm) => vm.LoadDataCommand);
    }
}