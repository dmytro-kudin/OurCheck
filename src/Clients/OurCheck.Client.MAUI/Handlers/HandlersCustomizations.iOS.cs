using UIKit;

namespace OurCheck.Client.MAUI.Handlers;

public partial class HandlersCustomizations
{
    public static void Apply()
    {
        ApplyCollectionViewRespectSafeArea();
    }

    private static void ApplyCollectionViewRespectSafeArea()
    {
        Microsoft.Maui.Controls.Handlers.Items2.CollectionViewHandler2.Mapper.AppendToMapping("RespectSafeArea",
            (handler, view) =>
            {
// #if IOS || MACCATALYST
                var collectionView = handler.PlatformView as UICollectionView
                                     ?? handler.PlatformView.Subviews.OfType<UICollectionView>().FirstOrDefault();
                collectionView?.ContentInsetAdjustmentBehavior =
                    UIScrollViewContentInsetAdjustmentBehavior.Always;
// #endif
            });
    }
}