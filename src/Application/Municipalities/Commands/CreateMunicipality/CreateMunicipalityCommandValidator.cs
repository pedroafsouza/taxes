using FluentValidation;
using Taxes.Application.Municipalities.Commands.CreateMunicipality;

namespace Taxes.Application.Municipalities.Commands.Municipalities
{
    public class CreateMunicipalityCommandValidator : AbstractValidator<CreateMunicipalityCommand>
    {
        public CreateMunicipalityCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
