using MediatR;
using StockManagement.Application.Responses;

namespace StockManagement.Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery: IRequest<GetProductDetailsQueryResponse>
    {
        public int ProductId { get; set; }
    }
}
