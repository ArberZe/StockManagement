using FluentValidation;
using StockManagement.Application.Contracts.Persistence;

namespace StockManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Plot�so emrin.")
            .NotNull()
            .MaximumLength(50).WithMessage("Emri nuk mund te kete me shume se 50 karaktere.");

        RuleFor(p => p.SellingPrice)
            .NotEmpty().WithMessage("Cmimi shitjes �sht� fush� e detyrueshme.")
            .NotNull()
            .GreaterThan(0).WithMessage("Cmimi shitjes nuk mund t� jet� zero");

        RuleFor(p => p.CompanyId)
            .NotEmpty().WithMessage("Zgjedh firm�n.")
            .NotNull();

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Zgjedh kategorin�.")
            .NotNull();
    }
}