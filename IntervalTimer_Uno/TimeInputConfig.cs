namespace IntervalTimer_Uno;

public record TimeInputConfig
{
    public TimeSpan StartTime { get; init; }
    public TimeSpan EndTime { get; init; }
    public TimeSpan Interval { get; init; }
}
