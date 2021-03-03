using FluentValidation;

namespace Taxes.Application.TaxSchedules.Commands.CreateTaxSchedule
{
    public class UpdateTaxScheduleCommandValidator : AbstractValidator<CreateTaxScheduleCommand>
    {
        public UpdateTaxScheduleCommandValidator()
        {
            RuleFor(v => v.Value)
                .GreaterThan(0);
        }
    }
}
