using OurCheck.Client.MAUI;

// This assembly attribute must sit above the namespace!
[assembly: System.Reflection.Metadata.MetadataUpdateHandler(typeof(HotReloadHandler))]

namespace OurCheck.Client.MAUI;

public static class HotReloadHandler
{
    // We will subscribe to this event in our UI pages
    public static event Action? UpdateApplicationEvent;

    // The .NET runtime expects this exact method signature
    internal static void ClearCache(Type[]? types) { }

    // The .NET runtime calls this immediately after injecting the new C# code
    internal static void UpdateApplication(Type[]? types)
    {
        // Tell the app to redraw
        MainThread.BeginInvokeOnMainThread(() => UpdateApplicationEvent?.Invoke());
    }
}