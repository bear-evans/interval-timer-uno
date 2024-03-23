namespace IntervalTimer_Uno.Presentation;

/// <summary> View for the settings management screen. </summary>
public sealed partial class SettingsPage : Page
{
    public SettingsPage()
    {
        this.DataContext<SettingsViewModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Required)
            .Background(Theme.Brushes.Background.Medium)
            .Content(
                new Grid()
                    .SafeArea(SafeArea.InsetMask.All)
                    .RowDefinitions("*, Auto, *")
                    .Children(
                        new StackPanel()
                            .Grid(row: 1, column: 1)
                            .HorizontalAlignment(HorizontalAlignment.Center)
                            .VerticalAlignment(VerticalAlignment.Top)
                            .Spacing(16)
                            .Children(
                                new StackPanel().Orientation(Orientation.Horizontal)
                                    .Spacing(50)
                                    .HorizontalAlignment(HorizontalAlignment.Center)
                                    .Children(
                                        new TextBlock().Text("Start Time"),
                                        new TimePicker()
                                    )
                    )
            )
        ));
    }
}
