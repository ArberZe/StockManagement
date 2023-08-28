using StockManagement.Domain.Entities;

namespace StockManagement.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        //Task<Category> GetMostUsedCategory();
    }
}
