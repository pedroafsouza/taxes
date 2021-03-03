using Taxes.Domain.Common;
using System.Threading.Tasks;

namespace Taxes.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
