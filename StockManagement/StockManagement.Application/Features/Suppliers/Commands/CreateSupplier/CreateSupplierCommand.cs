using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommand: IRequest<CreateSupplierCommandResponse>
    {
        public int SupplierId { get; set; }
        public string? Name { get; set; }
        public int CountryId { get; set; }
    }
}
