namespace IntervalTimer_Uno.Business.Models;

/// <summary> Container class for instantiated application settings. </summary>
public record Settings
{
    public TimeSpan StartTime { get; init; }

    public TimeSpan EndTime { get; init; }

    public TimeSpan Interval { get; init; }
}
