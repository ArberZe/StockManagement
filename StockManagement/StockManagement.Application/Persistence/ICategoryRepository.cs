using StockManagement.Domain.Entities;

namespace StockManagement.Application.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
