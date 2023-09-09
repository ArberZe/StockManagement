using StockManagement.App.Services;

namespace StockManagement.App.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal SellingPrice { get; set; }
        public CategoryDto Category { get; set; } = default!;
        public CompanyDto Company { get; set; } = default!;
    }
}