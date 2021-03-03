using Taxes.Application.Common.Interfaces;
using FluentValidation;

namespace Taxes.Application.TaxSchedules.Commands.CreateTaxSchedule
{
    public class CreateTaxScheduleCommandValidator : AbstractValidator<CreateTaxScheduleCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTaxScheduleCommandValidator(IApplicationDbContext context)
        {
            _context = context;
        }
    }
}
