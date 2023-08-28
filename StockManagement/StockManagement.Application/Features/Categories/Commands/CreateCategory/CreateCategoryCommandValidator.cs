using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() 
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} eshte fushe e detyrueshme.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} nuk duhet te kaloje 50 karaktere.");
        }
    }
}
