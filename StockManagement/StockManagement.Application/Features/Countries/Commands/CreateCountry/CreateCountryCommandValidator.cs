
using FluentValidation;

namespace StockManagement.Application.Features.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandValidator: AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Shkruaj emrin.")
            .NotNull()
            .MaximumLength(50).WithMessage("Emri nuk mund te kete me shume se 50 karaktere.");
        }
    }
}
