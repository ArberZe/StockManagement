using StockManagement.App.Services;

namespace StockManagement.App.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; } = default!;
        public decimal SellingPrice { get; set; }
    }
}