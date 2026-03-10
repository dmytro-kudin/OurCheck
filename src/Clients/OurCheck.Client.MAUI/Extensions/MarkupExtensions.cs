namespace OurCheck.Client.MAUI.Extensions;

public static class MarkupExtensions
{
    public static T Bind<T>(this T bindable, BindableProperty property, BindingBase binding) where T : BindableObject
    {
        bindable.SetBinding(property, binding);
        return bindable;
    }
}