
using StockManagement.Domain.Entities;

namespace StockManagement.Application.Contracts.Persistence
{
    public interface ISupplierRepository: IAsyncRepository<Supplier>
    {
    }
}
