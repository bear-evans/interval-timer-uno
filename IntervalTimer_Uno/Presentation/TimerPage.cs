namespace IntervalTimer_Uno.Presentation;

public sealed partial class TimerPage : Page
{
    public TimerPage()
    {
        this.DataContext<TimerViewModel>((page, vm) => page
            .Background(Theme.Brushes.Background.Default)
            .Content(
                new Grid()
                    .SafeArea(SafeArea.InsetMask.All)
                    .RowDefinitions("*, Auto, *")
                    .ColumnDefinitions("*, Auto, *")
                    .Children(
                        new StackPanel()
                            .Grid(row: 1, column: 1)
                            .HorizontalAlignment(HorizontalAlignment.Center)
                            .VerticalAlignment(VerticalAlignment.Center)
                            .Margin(0, 50)
                            .Spacing(16)
                            .Children(
                                new TextBlock().Name("CountdownDisplay")
                                    .Text(x => x.Bind(() => vm.CountdownDisplayText))
                                    .HorizontalAlignment(HorizontalAlignment.Center)
                                    .FontSize(34),
                                new ProgressBar().Name("CountdownBar")
                                    .Value(() => vm.CountdownProgress)
                                    .Width(500)
                                    .Height(50)
                                    .HorizontalAlignment(HorizontalAlignment.Stretch)
                                    .Foreground(() => vm.BarColor)
                            ),
                        new Button().Name("PrimaryTimerButton")
                            .Background(Theme.Brushes.Primary.Default)
                            .Content("Start")
                            .Grid(row: 2, column: 1)
                            .HorizontalAlignment(HorizontalAlignment.Center)
                            .VerticalAlignment(VerticalAlignment.Top)
                            .Command(() => vm.PrimaryClick),
                        new Button().Name("SettingsButton")
                            .Grid(row: 0, column: 2)
                            .Content("Settings")
                            .HorizontalAlignment(HorizontalAlignment.Right)
                            .VerticalAlignment(VerticalAlignment.Top)
                            .Command(() => vm.SettingsClick)
                    )
        ));
    }
}
