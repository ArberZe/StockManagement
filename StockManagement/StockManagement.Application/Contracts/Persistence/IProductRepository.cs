using StockManagement.Domain.Entities;

namespace StockManagement.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {

    }
}
