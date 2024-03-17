namespace IntervalTimer_Uno.Presentation;

public partial class TimerViewModel : ObservableObject
{
    #region External References

    // ----------------------------------------------
    private INavigator navigator;
    private Business.Models.Timer timer;
    // ----------------------------------------------

    #endregion External References

    #region Events

    // ----------------------------------------------
    /// <summary> Command interface for the primary button click handler. </summary>
    public ICommand PrimaryClick { get; }

    /// <summary> Command interface for the settings button click handler. </summary>
    public ICommand SettingsClick { get; }
    // ----------------------------------------------

    #endregion Events

    #region Properties

    // ----------------------------------------------

    // Countdown timer display properties
    [ObservableProperty] public string countdownDisplayText;
    [ObservableProperty] public double countdownProgress;

    // start time input
    [ObservableProperty] public int startHour;
    [ObservableProperty] public int startMinute;

    // end time input
    [ObservableProperty] public int endHour;
    [ObservableProperty] public int endMinute;

    // interval time input
    [ObservableProperty] public int intervalHour;
    [ObservableProperty] public int intervalMinute;
    [ObservableProperty] public int intervalSecond;
    // ----------------------------------------------

    #endregion Properties

    // ==============================================

    #region Constructor

    public TimerViewModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigation)
    {
        navigator = navigation;

        // create a new timer object to serve as the backing
        timer = new();

        PrimaryClick = new AsyncRelayCommand(PrimaryButtonClicked);
        SettingsClick = new AsyncRelayCommand(SettingsClicked);

        countdownDisplayText = "Press Start";

        // event listeners to timer
        timer.CountdownDisplayChanged += OnCountdownDisplayChanged;
        timer.TimebarProgressChanged += OnTimebarProgressChanged;
    }

    #endregion Constructor

    // ==============================================

    #region User Commands

    /// <summary> Handles clicks to the start and stop button. </summary>
    public async Task PrimaryButtonClicked()
    {
        timer.StartStopTimer();
    }

    /// <summary> Switches to the settings page when clicked. </summary>
    public async Task SettingsClicked()
    {
        // switch to settings
    }

    #endregion User Commands

    // ==============================================

    #region Display Updates

    /// <summary> Updates the countdown display text when the timer updates. </summary>
    /// <param name="value"> The new string to display. </param>
    public void OnCountdownDisplayChanged(string value)
    {
        CountdownDisplayText = value;
    }

    /// <summary> Updates the fill level of the time bar when time progress changes. </summary>
    /// <param name="value"> The new progress value. </param>
    public void OnTimebarProgressChanged(double value)
    {
        CountdownProgress = value * 100;
    }

    /// <summary> Changes the color of the time bar in response to time and state changes. </summary>
    /// <param name="value"> The new color to display. </param>
    public void OnTimebarColorChanged(Color value)
    {
    }

    #endregion Display Updates
}
