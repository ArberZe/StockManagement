using StockManagement.Application.Features.Products.Queries.GetProductsExport;

namespace StockManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportProductsToCsv(List<ProductExportDto> productExportDtos);
    }
}