using MediatR;

namespace StockManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand: IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public decimal SellingPrice { get; set; }
    
    public override string ToString()
    {
        return $"Event name: {Name}; Price: {SellingPrice}; CategoryId: {CategoryId}";
    }
}