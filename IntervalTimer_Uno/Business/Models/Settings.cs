namespace IntervalTimer_Uno.Business.Models;

/// <summary> Container class for instantiated application settings. </summary>
public record Settings
{
    public int StartHour { get; set; }
    public int StartMinute { get; set; }
    public int EndHour { get; set; }
    public int EndMinute { get; set; }
    public int IntervalHour { get; set; }
    public int IntervalMinute { get; set; }
    public int IntervalSecond { get; set; }
}
