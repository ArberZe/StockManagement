namespace StockManagement.Application.Features.Products.Queries.GetProductsExport
{
    public class ProductExportDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal SellingPrice { get; set; }
    }
}