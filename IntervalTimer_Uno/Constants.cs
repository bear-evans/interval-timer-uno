namespace IntervalTimer_Uno;

public static class Constants
{
    public static ApplicationDataContainer Settings = Windows.Storage.ApplicationData.Current.LocalSettings;

    public static class SettingStrings
    {
        public static readonly string StartHour = "Start Hour";
        public static readonly string StartMinute = "Start Minute";
        public static readonly string EndHour = "End Hour";
        public static readonly string EndMinute = "End Minute";
        public static readonly string IntervalHour = "Interval Hour";
        public static readonly string IntervalMinute = "Interval Minute";
        public static readonly string IntervalSecond = "Interval Second";
    }
}
