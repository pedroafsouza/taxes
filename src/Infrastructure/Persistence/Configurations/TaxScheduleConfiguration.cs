using Taxes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Taxes.Infrastructure.Persistence.Configurations
{
    public class TaxScheduleConfiguration : IEntityTypeConfiguration<TaxSchedule>
    {
        public void Configure(EntityTypeBuilder<TaxSchedule> builder)
        {
        }
    }
}