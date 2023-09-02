using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Contracts
{
    public interface IProductDataService
    {
        Task<List<ProductViewModel>> GetAllProducts();
        Task<ApiResponse<ProductDto>> CreateProduct(ProductViewModel productViewModel);
    }
}
