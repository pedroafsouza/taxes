using Taxes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Taxes.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Municipality> Municipalities { get; set; }

        DbSet<TaxSchedule> TaxSchedules { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
