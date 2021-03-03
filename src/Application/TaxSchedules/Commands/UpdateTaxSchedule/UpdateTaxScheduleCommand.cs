using Taxes.Application.Common.Exceptions;
using Taxes.Application.Common.Interfaces;
using Taxes.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Taxes.Domain.Enums;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using Taxes.Application.Common.Extensions;

namespace Taxes.Application.TaxSchedules.Commands.UpdateTaxSchedule
{
    public class UpdateTaxScheduleCommand : IRequest
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public double Value { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TimePeriod TimePeriod { get; set; }
    }

    public class UpdateTaxScheduleCommandHandler : IRequestHandler<UpdateTaxScheduleCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTaxScheduleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTaxScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TaxSchedules.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TaxSchedule), request.Id);
            }

            entity.StartDate = request.StartDate;
            entity.EndDate = request.StartDate.Date.EndDateFromTimePeriod(request.TimePeriod);
            entity.TimePeriod = request.TimePeriod;
            entity.Value = request.Value;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
