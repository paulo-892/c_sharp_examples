using System;
using System.Globalization;
using System.Runtime.InteropServices;


public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        string timeZoneId = GetTimeZoneId(location);

        return TimeZoneInfo.ConvertTimeToUtc(
            DateTime.Parse(appointmentDateDescription), TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment - new TimeSpan(1, 0, 0, 0),
            AlertLevel.Standard => appointment - new TimeSpan(0, 1, 45, 0),
            AlertLevel.Late => appointment - new TimeSpan(0, 0, 30, 0),
            _ => throw new ArgumentException("Issue with argument!")
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var timeZoneId = GetTimeZoneId(location);

        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        return timeZoneInfo.IsDaylightSavingTime(dt) != timeZoneInfo.IsDaylightSavingTime(dt.AddDays(-7));
    }

    private static string GetTimeZoneId(Location location)
    {
        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        return location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new ArgumentException("Issue with argument!")
        };
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var culture = location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => throw new ArgumentException("Issue with argument!")
        };

        var cultureInfo = CultureInfo.GetCultureInfo(culture);

        var isValid = DateTime.TryParse(dtStr, cultureInfo, DateTimeStyles.None, out var resDateTime);

        return isValid ? resDateTime : new(1, 1, 1);
    }
}
