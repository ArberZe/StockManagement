using FluentValidation;
using StockManagement.Application.Contracts.Persistence;

namespace StockManagement.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} eshte fushe e detyrueshme.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} nuk mund te kete me shume se 50 karaktere.");

            RuleFor(p => p.SellingPrice)
                .NotEmpty().WithMessage("{PropertyName} eshte fushe e detyrueshme.")
                .NotNull()
                .GreaterThan(0);
        }
    }
}