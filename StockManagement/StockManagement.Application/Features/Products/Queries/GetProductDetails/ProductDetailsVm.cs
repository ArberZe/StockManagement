namespace StockManagement.Application.Features.Products.Queries.GetProductDetails
{
    public class ProductDetailsVm
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = String.Empty;
        public CategoryDto Category { get; set; } = default!;
        public decimal SellingPrice { get; set; }
    }
}