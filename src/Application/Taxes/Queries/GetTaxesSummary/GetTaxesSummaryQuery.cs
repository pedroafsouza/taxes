using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Taxes.Application.Common.Interfaces;
using Taxes.Application.TaxSchedules.Queries.GetTaxSchedules;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Taxes.Domain.Entities;
using Taxes.Application.Common.Exceptions;

namespace Taxes.Application.TaxSchedules.Queries.GetTaxScheduleSummary
{
    public class GetTaxesSummaryQuery : IRequest<TaxesSummaryResponse>
    {
        public string MunicipalityName { get; set; }

        public DateTime Date { get; set; }
    }

    public class GetTaxeScheduleSummaryQueryHandler : IRequestHandler<GetTaxesSummaryQuery, TaxesSummaryResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTaxeScheduleSummaryQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<TaxesSummaryResponse> Handle(GetTaxesSummaryQuery request, CancellationToken cancellationToken)
        {
            var municipality = _context.Municipalities.FirstOrDefault(p => p.Name == request.MunicipalityName);
            if (municipality == null)
            {
                throw new NotFoundException(nameof(Municipality), request.MunicipalityName);
            }

            var taxSchedules = _context.TaxSchedules
                                       .Where(p => p.Municipality.Name == request.MunicipalityName &&
                                                   p.StartDate >= request.Date && request.Date <= p.EndDate);

            var result = taxSchedules.ProjectTo<TaxScheduleResponse>(_mapper.ConfigurationProvider);

            return Task.FromResult(new TaxesSummaryResponse
            {
                MunicipalityId = municipality.Id,
                MunicipalityName = municipality.Name,
                Result = taxSchedules.ToList().Sum(p => p.Value),
                TaxSchedules = taxSchedules.ProjectTo<TaxScheduleResponse>(_mapper.ConfigurationProvider)
            });
        }
    }
}
