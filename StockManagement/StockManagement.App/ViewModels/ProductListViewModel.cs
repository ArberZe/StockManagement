namespace StockManagement.App.ViewModels
{
    public class ProductListViewModel
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
