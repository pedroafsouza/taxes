using Taxes.Application.Common.Interfaces;
using Taxes.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Taxes.Domain.Enums;
using System;
using System.Linq;
using Taxes.Application.Common.Extensions;
using Taxes.Application.TaxSchedules.Queries.GetTaxSchedules;
using AutoMapper;
using System.Text.Json.Serialization;

namespace Taxes.Application.TaxSchedules.Commands.CreateTaxSchedule
{
    public class CreateTaxScheduleCommand : IRequest<TaxScheduleResponse>
    {
        [JsonIgnore]
        public Int32 MunicipalityId { get; set; }

        public DateTime StartDate { get; set; }

        public TimePeriod TimePeriod { get; set; }

        public double Value { get; set; }
    }

    public class CreateTaxScheduleCommandHandler : IRequestHandler<CreateTaxScheduleCommand, TaxScheduleResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTaxScheduleCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TaxScheduleResponse> Handle(CreateTaxScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = new TaxSchedule
            {
                StartDate = request.StartDate.Date,
                EndDate = request.StartDate.Date.EndDateFromTimePeriod(request.TimePeriod),
                TimePeriod = request.TimePeriod,
                Value = request.Value,
                Municipality = _context.Municipalities.FirstOrDefault(municipality => municipality.Id == request.MunicipalityId)
            };

            _context.TaxSchedules.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TaxScheduleResponse>(entity);
        }
    }
}
