using StockManagement.Application.Responses;

namespace StockManagement.Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryResponse: BaseResponse
    {
        public GetProductDetailsQueryResponse() : base()
        {
            
        }

        public ProductDetailsVm Product { get; set; } = default!;
    }
}
