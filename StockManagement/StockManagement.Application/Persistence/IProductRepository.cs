using StockManagement.Domain.Entities;

namespace StockManagement.Application.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {

    }
}
