namespace StockManagement.App.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
