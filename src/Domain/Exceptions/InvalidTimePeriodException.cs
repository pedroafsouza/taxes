using System;
using Taxes.Domain.Enums;

namespace Taxes.Domain.Exceptions
{
    public class InvalidTimePeriodException : Exception
    {
        public InvalidTimePeriodException(TimePeriod timePeriod)
            : base($"Invalid time period {timePeriod}.")
        {
        }
    }
}
