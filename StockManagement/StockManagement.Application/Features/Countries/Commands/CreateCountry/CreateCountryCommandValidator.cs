
using FluentValidation;

namespace StockManagement.Application.Features.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandValidator: AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} eshte fushe e detyrueshme.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} nuk mund te kete me shume se 50 karaktere.");
        }
    }
}
