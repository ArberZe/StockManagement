using Microsoft.EntityFrameworkCore;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;
using System.Linq;

namespace StockManagement.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StockManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Category>> ListCategoriesByCreatedDateDescending()
        {
            var allCategories = await _dbContext.Categories.ToListAsync();
            allCategories.OrderByDescending(e => e.CreatedDate);
            return allCategories;
        }
    }
}