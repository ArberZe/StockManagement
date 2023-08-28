using StockManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandResponse : BaseResponse
    {
        public CreateProductCommandResponse() : base()
        {

        }

        public CreateProductDto Product { get; set; } = default!;
    }
}
