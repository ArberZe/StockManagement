
using StockManagement.Application.Responses;

namespace StockManagement.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandResponse: BaseResponse
    {
        public CreateSupplierCommandResponse():base()
        {
            
        }

        public CreateSupplierDto Supplier { get; set; }
    }
}
