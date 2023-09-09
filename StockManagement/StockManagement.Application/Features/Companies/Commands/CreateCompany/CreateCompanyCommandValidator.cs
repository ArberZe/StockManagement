using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator: AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} eshte fushe e detyrueshme.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} nuk mund te kete me shume se 50 karaktere.");
        }
    }
}
