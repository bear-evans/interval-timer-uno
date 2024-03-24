namespace IntervalTimer_Uno.Presentation;

/// <summary> View Model of the Settings View. </summary>
public partial class SettingsViewModel : ObservableObject
{
    #region External References

    // ------------------------------------------
    private INavigator navigator;
    private IOptions<AppConfig> appConfig;
    private IStringLocalizer localizer;
    private IWritableOptions<TimeInputConfig> timeInputConfig;
    // ------------------------------------------

    #endregion External References

    #region Settings

    // ------------------------------------------
    [ObservableProperty] private TimeSpan startTime;
    [ObservableProperty] private TimeSpan endTime;
    [ObservableProperty] private TimeSpan interval;
    // ------------------------------------------

    #endregion Settings

    #region Input Fields

    // ------------------------------------------
    [ObservableProperty] private int intervalHourField;
    [ObservableProperty] private int intervalMinuteField;
    [ObservableProperty] private int intervalSecondField;

    /// <summary> Event fired when an interval input field changes. </summary>
    private Action IntervalInputChanged { get; set; } = delegate { };
    // ------------------------------------------

    #endregion Input Fields

    // ==============================================

    #region Constructor

    public SettingsViewModel(IStringLocalizer localizer,
        IOptions<AppConfig> appinfo,
        INavigator navigator,
        IWritableOptions<TimeInputConfig> config)
    {
        this.localizer = localizer;
        this.appConfig = appinfo;
        this.navigator = navigator;
        this.timeInputConfig = config;

        StartTime = timeInputConfig.Value.StartTime;
        EndTime = timeInputConfig.Value.EndTime;
        Interval = timeInputConfig.Value.Interval;

        IntervalInputChanged += OnIntervalInputChanged;
    }

    #endregion Constructor

    // ==============================================

    #region Event Listeners

    /// <summary> Fires when the hour field of the interval input setting changes. </summary>
    /// <param name="value"> The new value. </param>
    partial void OnIntervalHourFieldChanged(int value)
    {
        IntervalInputChanged?.Invoke();
    }

    /// <summary> Fires when the hour field of the interval minute setting changes. </summary>
    /// <param name="value"> The new value. </param>
    partial void OnIntervalMinuteFieldChanged(int value)
    {
        IntervalInputChanged?.Invoke();
    }

    /// <summary> Fires when the second field of the interval input setting changes. </summary>
    /// <param name="value"> The new value. </param>
    partial void OnIntervalSecondFieldChanged(int value)
    {
        IntervalInputChanged?.Invoke();
    }

    /// <summary>
    /// Sets the saved interval to a TimeSpan created from the interval input fields when their
    /// contents change.
    /// </summary>
    private void OnIntervalInputChanged()
    {
        Interval = ConstructIntervalObject();
        SaveIntervalPeriod(Interval);
    }

    #endregion Event Listeners

    // ==============================================

    #region Setting Processing

    /// <summary> Saves the start time to the app configuration. </summary>
    /// <param name="newTime"> The new time. </param>
    private void SaveStartTime(TimeSpan newTime)
    {
        timeInputConfig.UpdateAsync(timeInputConfig => timeInputConfig with { StartTime = newTime });
    }

    /// <summary> Saves a new end time to the app configuration. </summary>
    /// <param name="newTime"> The new time. </param>
    private void SaveEndTime(TimeSpan newTime)
    {
        timeInputConfig.UpdateAsync(timeInputConfig => timeInputConfig with { EndTime = newTime });
    }

    /// <summary> Saves an interval period to the app configuration.. </summary>
    /// <param name="newPeriod"> The new value of Interval. </param>
    private void SaveIntervalPeriod(TimeSpan newPeriod)
    {
        timeInputConfig.UpdateAsync(timeInputConfig => timeInputConfig with { Interval = newPeriod });
    }

    /// <summary> Constructs a new Timespan object from the interval input fields. </summary>
    /// <returns> A TimeSpan representation of the interval. </returns>
    private TimeSpan ConstructIntervalObject()
    {
        return new TimeSpan(IntervalHourField, IntervalMinuteField, IntervalSecondField);
    }

    #endregion Setting Processing
}
