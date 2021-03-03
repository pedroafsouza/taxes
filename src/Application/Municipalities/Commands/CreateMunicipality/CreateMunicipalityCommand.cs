using Taxes.Application.Common.Interfaces;
using Taxes.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Taxes.Application.Municipalities.Commands.CreateMunicipality
{
    public class CreateMunicipalityCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateMunicipalityCommandHandler : IRequestHandler<CreateMunicipalityCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMunicipalityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Handle(CreateMunicipalityCommand request, CancellationToken cancellationToken)
        {
            var entity = new Municipality
            {
                Name = request.Name
            };

            _context.Municipalities.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
