using StockManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse: BaseResponse
    {
        public CreateCategoryCommandResponse(): base()
        {
            
        }
        public CreateCategoryDto Category { get; set; } = default!;
    }
}
