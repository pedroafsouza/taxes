using Taxes.Application.Common.Exceptions;
using Taxes.Application.Common.Interfaces;
using Taxes.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Taxes.Application.Municipalities.Commands.DeleteMunicipality
{
    public class DeleteMunicipalityCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteMunicipalityCommandHandler : IRequestHandler<DeleteMunicipalityCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMunicipalityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMunicipalityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Municipalities.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Municipality), request.Id);
            }

            _context.Municipalities.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
