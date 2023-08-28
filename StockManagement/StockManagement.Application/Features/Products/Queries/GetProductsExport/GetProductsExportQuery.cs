using MediatR;

namespace StockManagement.Application.Features.Products.Queries.GetProductsExport
{
    public class GetProductsExportQuery : IRequest<ProductExportFileVm>
    {
    }
}
