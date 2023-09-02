namespace StockManagement.Application.Features.Products.Queries.GetProductsList
{
    public class ProductListVm
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal SellingPrice { get; set; }
    }
}
