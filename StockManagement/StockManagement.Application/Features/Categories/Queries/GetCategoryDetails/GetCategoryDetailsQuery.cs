using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQuery: IRequest<CategoryDetailsVm>
    {
        public int CategoryId { get; set; }
    }
}
