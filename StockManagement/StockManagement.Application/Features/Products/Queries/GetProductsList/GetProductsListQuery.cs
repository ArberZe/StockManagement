using MediatR;

namespace StockManagement.Application.Features.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<List<ProductListVm>>
    {

    }
}
