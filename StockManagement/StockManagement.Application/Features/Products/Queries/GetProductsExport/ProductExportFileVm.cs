namespace StockManagement.Application.Features.Products.Queries.GetProductsExport
{
    public class ProductExportFileVm
    {
        public string ProductExportFilename { get; set; } = String.Empty;
        public string ContentType { get; set; } = String.Empty;
        public byte[]? Data { get; set; }
    }
}