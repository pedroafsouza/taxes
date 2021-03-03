using Taxes.Application.Common.Interfaces;
using System;

namespace Taxes.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
