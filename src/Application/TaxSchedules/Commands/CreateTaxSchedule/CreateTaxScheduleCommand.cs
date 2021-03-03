using Taxes.Application.Common.Interfaces;
using Taxes.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Taxes.Domain.Enums;
using System;
using System.Linq;
using Taxes.Application.Common.Extensions;

namespace Taxes.Application.TaxSchedules.Commands.CreateTaxSchedule
{
    public class CreateTaxScheduleCommand : IRequest<int>
    {
        public Int32 MunicipalityId { get; set; }

        public DateTime StartDate { get; set; }

        public TimePeriod TimePeriod { get; set; }

        public double Value { get; set; }
    }

    public class CreateTaxScheduleCommandHandler : IRequestHandler<CreateTaxScheduleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTaxScheduleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTaxScheduleCommand request, CancellationToken cancellationToken)
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

            return entity.Id;
        }
    }
}
