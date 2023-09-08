using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Contracts
{
    public interface ISupplierDataService
    {
        Task<List<SupplierListViewModel>> GetAllSuppliers();
        //Task<ApiResponse<CreateSupplierDto>> CreateSupplier(SupplierViewModel supplierViewModel);
    }
}
