using MediatR;

namespace StockManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductEvent: IRequest<int>
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public int CategoryId { get; set; }
    public decimal SellingPrice { get; set; }
    
    public override string ToString()
    {
        return $"Event name: {Name}; Price: {SellingPrice}; CategoryId: {CategoryId}";
    }
}