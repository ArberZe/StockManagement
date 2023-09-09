using StockManagement.App.Services.Base;
using StockManagement.App.Services;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Contracts
{
    public interface IProductDataService
    {
        Task<List<ProductListViewModel>> GetAllProducts();
        Task<ProductViewModel> GetProductById(int id);
        Task<ProductDetailsViewModel> GetProductDetailsById(int id);
        Task<ApiResponse<int>> UpdateProduct(ProductViewModel productViewModel);
        Task<ApiResponse<ProductDto>> CreateProduct(ProductViewModel productViewModel);
    }
}
