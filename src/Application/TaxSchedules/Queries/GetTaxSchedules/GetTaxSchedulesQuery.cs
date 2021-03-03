using AutoMapper;
using AutoMapper.QueryableExtensions;
using Taxes.Application.Common.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Taxes.Application.TaxSchedules.Queries.GetTaxSchedules
{
    public class GetTaxSchedulesQuery : IRequest<IQueryable<TaxScheduleResponse>>
    {
        public Int32 MunicipalityId { get; set; }
    }

    public class GetTaxSchedulesQueryHandler : IRequestHandler<GetTaxSchedulesQuery, IQueryable<TaxScheduleResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTaxSchedulesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IQueryable<TaxScheduleResponse>> Handle(GetTaxSchedulesQuery request, CancellationToken cancellationToken)
        {
            var result = _context
                 .TaxSchedules.Where(p => p.Municipality.Id == request.MunicipalityId
                 ).ProjectTo<TaxScheduleResponse>(_mapper.ConfigurationProvider);
            return Task.FromResult(result);
        }
    }
}
