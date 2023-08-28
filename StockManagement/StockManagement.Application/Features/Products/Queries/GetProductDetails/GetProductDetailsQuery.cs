using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery: IRequest<ProductDetailsVm>
    {
        public int ProductId { get; set; }
    }
}
