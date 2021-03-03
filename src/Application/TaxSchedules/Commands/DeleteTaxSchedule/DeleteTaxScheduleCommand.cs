using Taxes.Application.Common.Exceptions;
using Taxes.Application.Common.Interfaces;
using Taxes.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Taxes.Application.TaxSchedules.Commands.DeleteTaxSchedule
{
    public class DeleteTaxScheduleCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTaxScheduleCommandHandler : IRequestHandler<DeleteTaxScheduleCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTaxScheduleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTaxScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TaxSchedules
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TaxSchedule), request.Id);
            }

            _context.TaxSchedules.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
