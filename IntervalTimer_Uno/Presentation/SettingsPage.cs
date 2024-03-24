namespace IntervalTimer_Uno.Presentation;

/// <summary> View for the settings management screen. </summary>
public sealed partial class SettingsPage : Page
{
    #region Design Variables

    // ---------------------------------------------
    private readonly float settingSpacing = 16;
    private readonly float settingMargin = 0;
    private readonly float settingHeight = 60;
    // ---------------------------------------------

    #endregion Design Variables

    #region Design Snippets

    // ---------------------------------------------
    /// <summary> Template for a setting entry wrapper panel. </summary>
    private StackPanel SettingPanel
    {
        get
        {
            return new StackPanel()
                        .Orientation(Orientation.Horizontal)
                        .Spacing(50)
                        .Margin(settingMargin)
                        .HorizontalAlignment(HorizontalAlignment.Center);
        }
    }

    private TimePicker TimeSettingPicker
    {
        get
        {
            return new TimePicker()
                .Height(settingHeight);
        }
    }

    /// <summary> Template for a typed time input box. </summary>
    private TextBox IntervalInputBox
    {
        get
        {
            TextBox box = new TextBox();
            InputScope scope = new InputScope();
            InputScopeName scopeName = new InputScopeName();
            scopeName.NameValue = InputScopeNameValue.NumberFullWidth;
            scope.Names.Add(scopeName);

            box.InputScope = scope;

            box.Height = settingHeight;
            return box;
        }
    }

    /// <summary> Template for the : separators between interval input boxes. </summary>
    private TextBlock TimeSeperator
    {
        get
        {
            return new TextBlock()
                .Text(" : ")
                .VerticalAlignment(VerticalAlignment.Center)
            ;
        }
    }
    // ---------------------------------------------

    #endregion Design Snippets

    // =============================================================
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
                                new StackPanel()
                                    .Grid(row: 1, column: 1)
                                    .HorizontalAlignment(HorizontalAlignment.Center)
                                    .VerticalAlignment(VerticalAlignment.Top)
                                    .Spacing(settingSpacing)
                                    .Children(
                                        SettingPanel
                                            .Children(
                                                new TextBlock().Text("Start Time"),
                                                TimeSettingPicker.Time(x => x.Bind(() => vm.StartTime).TwoWay())
                                            ),
                                        SettingPanel
                                            .Children(
                                                new TextBlock().Text("End Time"),
                                                TimeSettingPicker.Time(x => x.Bind(() => vm.EndTime).TwoWay())
                                            ),
                                        SettingPanel
                                            .Children(
                                                new TextBlock().Text("Interval Period"),
                                                IntervalInputBox,
                                                TimeSeperator,
                                                IntervalInputBox,
                                                TimeSeperator,
                                                IntervalInputBox
                                            )
                                    )
                            )
                    )
            )
        );
    }
}
