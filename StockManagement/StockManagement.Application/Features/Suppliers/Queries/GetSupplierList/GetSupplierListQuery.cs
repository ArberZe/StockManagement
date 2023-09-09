
using MediatR;

namespace StockManagement.Application.Features.Suppliers.Queries.GetSupplierList
{
    public class GetSupplierListQuery: IRequest<List<SupplierListVm>>
    {
    }
}
