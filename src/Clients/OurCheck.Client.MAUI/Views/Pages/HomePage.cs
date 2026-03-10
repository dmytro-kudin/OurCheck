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
                    .Invoke(cv =>
                    {
                        // We create a local method so we can run it immediately AND attach it to the event
                        void FixIosInsets(object? sender, EventArgs e)
                        {
#if IOS
                            // 1. Get the MAUI wrapper container (which is just a standard UIView)
                            if (cv.Handler?.PlatformView is UIKit.UIView nativeContainer)
                            {
                                // 2. Search the container's children for the actual Apple UICollectionView
                                var nativeList = nativeContainer.Subviews.OfType<UIKit.UICollectionView>()
                                    .FirstOrDefault();

                                if (nativeList != null)
                                {
                                    // 3. Apply the native inset behavior!
                                    nativeList.ContentInsetAdjustmentBehavior =
                                        UIKit.UIScrollViewContentInsetAdjustmentBehavior.Always;
                                }
                            }
#endif
                        }

                        cv.HandlerChanged += FixIosInsets;

                        // Fallback: If the Handler is somehow already attached, run it right now
                        if (cv.Handler != null)
                        {
                            FixIosInsets(cv, EventArgs.Empty);
                        }
                    })

            }
            .Bind(RefreshView.IsRefreshingProperty, static (HomeViewModel vm) => vm.IsRefreshing)
            .Bind(RefreshView.CommandProperty, static (HomeViewModel vm) => vm.LoadDataCommand);
    }
}