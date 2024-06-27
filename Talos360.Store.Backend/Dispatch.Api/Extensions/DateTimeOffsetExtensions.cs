using System;

namespace Dispatch.Api.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset AvoidWeekend(this DateTimeOffset dateTimeOffset) 
        {
            switch (dateTimeOffset.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return dateTimeOffset.AddDays(2);
                case DayOfWeek.Sunday:
                    return dateTimeOffset.AddDays(1);
                default:
                    return dateTimeOffset;
            }
        }
    }
}
