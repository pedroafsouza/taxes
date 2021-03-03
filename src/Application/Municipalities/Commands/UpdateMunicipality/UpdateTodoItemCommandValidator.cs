using FluentValidation;

namespace Taxes.Application.Municipalities.Commands.UpdateMunicipality
{
    public class UpdateMunicipalityCommandValidator : AbstractValidator<UpdateMunicipalityCommand>
    {
        public UpdateMunicipalityCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
