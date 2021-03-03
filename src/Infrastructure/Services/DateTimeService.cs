using Taxes.Application.Common.Interfaces;
using System;
using Taxes.Domain.Enums;

namespace Taxes.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
