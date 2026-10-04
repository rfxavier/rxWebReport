using System;
using System.Globalization;

namespace rxDesktopReportClient
{
    internal static class DailyReportSchedule
    {
        internal static bool TryParseTimeOfDay(string value, out TimeSpan timeOfDay)
        {
            return TimeSpan.TryParseExact(value, @"hh\:mm", CultureInfo.InvariantCulture,
                out timeOfDay) && timeOfDay >= TimeSpan.Zero && timeOfDay < TimeSpan.FromDays(1);
        }

        internal static DateTime GetNextRun(DateTime now, TimeSpan timeOfDay)
        {
            DateTime nextRun = now.Date.Add(timeOfDay);
            return nextRun > now ? nextRun : nextRun.AddDays(1);
        }
    }
}
