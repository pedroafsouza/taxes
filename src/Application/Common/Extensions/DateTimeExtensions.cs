namespace Taxes.Application.Common.Extensions
{
    using System;
    using Taxes.Domain.Enums;
    using Taxes.Domain.Exceptions;

    public static class DateTimeExtensions
    {
        public static DateTime EndDateFromTimePeriod(this DateTime dt, TimePeriod timePeriod)
        {
            DateTime result;

            switch (timePeriod)
            {
                case TimePeriod.Daily:
                    result = dt;
                    break;
                case TimePeriod.Weekly:
                    result = dt.AddDays(7);
                    break;
                case TimePeriod.Monthly:
                    result = dt.AddMonths(1);
                    break;
                case TimePeriod.Yearly:
                    result = dt.AddYears(1);
                    break;
                default:
                    throw new InvalidTimePeriodException(timePeriod);
            }

            return result.AddTicks(-1).AddDays(1);
        }
    }
}
