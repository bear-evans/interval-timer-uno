namespace IntervalTimer_Uno.Presentation;

/// <summary> View for the settings management screen. </summary>
public sealed partial class SettingsPage : Page
{
    public SettingsPage()
    {
        // this.Data
        new Grid().SafeArea(SafeArea.InsetMask.All)
            .RowDefinitions("*, Auto, *");
    }
}
