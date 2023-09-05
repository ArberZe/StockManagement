using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand: IRequest<UpdateProductCommandResponse>
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
