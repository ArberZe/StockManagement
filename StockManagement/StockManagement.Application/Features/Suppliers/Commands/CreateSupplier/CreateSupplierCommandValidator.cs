
using FluentValidation;

namespace StockManagement.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandValidator: AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} eshte fushe e detyrueshme.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} nuk mund te kete me shume se 50 karaktere.");
        }
    }
}
