using FluentValidation;

namespace Taxes.Application.TaxSchedules.Commands.UpdateTaxSchedule
{
    public class UpdateTaxScheduleCommandValidator : AbstractValidator<UpdateTaxScheduleCommand>
    {
        public UpdateTaxScheduleCommandValidator()
        {
            RuleFor(v => v.Value)
                .GreaterThan(0);
        }
    }
}
