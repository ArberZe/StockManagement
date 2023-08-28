using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand: IRequest
    {
        public int ProductId { get; set; }
    }
}
