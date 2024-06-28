using System;

namespace Dispatch.Api.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset AddWorkingDays(this DateTimeOffset from, int days) 
        {
            var unassigned = days;
            var result = from;
            // Initially progress the result to the next non-weekend day without counting it
            switch (result.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    result = result.AddDays(2);
                    break;
                case DayOfWeek.Sunday:
                    result = result.AddDays(1);
                    break;
            }
            // Count through days requested, skipping weekends until we've arrived at the day count we asked for
            while (unassigned > 0)
            {
                switch (result.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        result = result.AddDays(3);
                        break;
                    case DayOfWeek.Saturday:
                        result = result.AddDays(2);
                        break;
                    default:
                        result = result.AddDays(1);
                        break;
                }
                unassigned--;
            }
            return result;
        }
    }
}
