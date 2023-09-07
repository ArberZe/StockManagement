using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;

namespace StockManagement.Persistence.Repositories
{
    public class CountryRepository: BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(StockManagementDbContext dbContext): base(dbContext)
        {
        }
    }
}
