using Taxes.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Taxes.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Municipalities.Any())
            {
                context.Municipalities.Add(new Municipality { Name = "Copenhagen" });
                context.Municipalities.Add(new Municipality { Name = "Kastrup" });
                context.Municipalities.Add(new Municipality { Name = "Lyngby" });

                await context.SaveChangesAsync();
            }
        }
    }
}
