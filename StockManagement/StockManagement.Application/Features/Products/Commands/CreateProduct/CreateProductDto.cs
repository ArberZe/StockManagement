namespace StockManagement.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}