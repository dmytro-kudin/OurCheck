using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Maui.Markup;
using OurCheck.Client.MAUI.Extensions;
using OurCheck.Dto.Appointment;

namespace OurCheck.Client.MAUI.Views.Cells;

public class AppointmentCell : ContentView
{
    public AppointmentCell()
    {
        Content = new Grid
        {
            Padding = new Thickness(15),
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = GridLength.Auto } 
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Auto }
            },
            Children = 
            {
                new VerticalStackLayout
                {
                    Spacing = 5,
                    Children = 
                    {
                        new Label { FontAttributes = FontAttributes.Bold, FontSize = 18 }
                            .Bind(Label.TextProperty,static (AppointmentDto dto) => dto.Note),

                        new Label { FontSize = 14 }
                            .Bind(Label.TextProperty, static (AppointmentDto dto) => dto.AppointmentTime, convert: (DateTimeOffset time) => time.ToString("f")),

                        new Label { FontSize = 14, TextColor = Colors.Gray }
                            .Bind(Label.TextProperty, static (AppointmentDto dto) => dto.PlaceName)
                    }
                }.Column(0),

                new Button 
                { 
                    Text = "Map",
                    WidthRequest = 40,
                    HeightRequest = 40,
                    Padding = 0,
                    Margin = new Thickness(10, 0, 0, 0),
                    VerticalOptions = LayoutOptions.Center,
                    Command = new Command<AppointmentDto>(async dto => 
                    {
                        if (!string.IsNullOrEmpty(dto?.PlaceUrl))
                            await Launcher.OpenAsync(dto.PlaceUrl);
                    })
                }.Column(1)
                .Bind(Button.IsVisibleProperty, Binding.Create(static (AppointmentDto dto) => dto.PlaceUrl, converter: new IsStringNotNullOrEmptyConverter()))
                .Bind(Button.CommandParameterProperty, Binding.Create(static (AppointmentDto dto) => dto))
            }
        };
    }
}
