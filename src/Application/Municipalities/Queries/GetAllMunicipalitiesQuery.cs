namespace Taxes.Application.Municipalities.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Taxes.Application.Common.Interfaces;
    using Taxes.Domain.Entities;

    public class GetAllMunicipalitiesQuery : IRequest<IEnumerable<MunicipalityResponse>>
    {
        public Int32? MunicipalityId { get; set; }
    }

    public class GetAllMunicipalitiesQueryHandler : IRequestHandler<GetAllMunicipalitiesQuery, IEnumerable<MunicipalityResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllMunicipalitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MunicipalityResponse>> Handle(GetAllMunicipalitiesQuery request, CancellationToken cancellationToken)
        {
            return _context
                    .Municipalities.Where(p => request.MunicipalityId == null || p.Id == request.MunicipalityId)
                    .ProjectTo<MunicipalityResponse>(_mapper.ConfigurationProvider);
        }
    }
}
