using MediatR;

namespace StockManagement.Application.Features.Products
{
    public class GetProductsListQuery : IRequest<List<ProductListVm>>
    {

    }
}
