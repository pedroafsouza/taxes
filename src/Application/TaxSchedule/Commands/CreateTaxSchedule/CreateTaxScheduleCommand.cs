using Taxes.Application.Common.Interfaces;
using Taxes.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Taxes.Domain.Enums;
using System;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Taxes.Application.TaxSchedules.Commands.CreateTaxSchedule
{
    public class CreateTaxScheduleCommand : IRequest<int>
    {
        public Int32 MunicipalityId { get; set; }

        public DateTime StartDate { get; set; }

        public TimePeriod TimePeriod { get; set; }
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
                StartDate = request.StartDate,
                TimePeriod = request.TimePeriod,
                Municipality = _context.Municipalities.FirstOrDefault(municipality => municipality.Id == request.MunicipalityId)
            };

            _context.TaxSchedules.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
