using System;
using Taxes.Domain.Enums;

namespace Taxes.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
