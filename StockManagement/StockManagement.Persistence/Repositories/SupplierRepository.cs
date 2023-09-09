
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;

namespace StockManagement.Persistence.Repositories
{
    public class SupplierRepository: BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(StockManagementDbContext dbContext): base(dbContext)
        {
        }
    }
}
