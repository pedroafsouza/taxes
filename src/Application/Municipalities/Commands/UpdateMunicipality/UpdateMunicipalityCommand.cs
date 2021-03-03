using Taxes.Application.Common.Exceptions;
using Taxes.Application.Common.Interfaces;
using Taxes.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Taxes.Application.Municipalities.Commands.UpdateMunicipality
{
    public class UpdateMunicipalityCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class UpdateMunicipalityCommandHandler : IRequestHandler<UpdateMunicipalityCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMunicipalityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMunicipalityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Municipalities.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TaxSchedule), request.Id);
            }

            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
