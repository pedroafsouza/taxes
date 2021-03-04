using Taxes.Application.Common.Interfaces;
using Taxes.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Taxes.Application.Municipalities.Queries;
using AutoMapper;

namespace Taxes.Application.Municipalities.Commands.CreateMunicipality
{
    public class CreateMunicipalityCommand : IRequest<MunicipalityResponse>
    {
        public string Name { get; set; }
    }

    public class CreateMunicipalityCommandHandler : IRequestHandler<CreateMunicipalityCommand, MunicipalityResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateMunicipalityCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MunicipalityResponse> Handle(CreateMunicipalityCommand request, CancellationToken cancellationToken)
        {
            var entity = new Municipality
            {
                Name = request.Name
            };

            _context.Municipalities.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<MunicipalityResponse>(entity);
        }
    }
}
