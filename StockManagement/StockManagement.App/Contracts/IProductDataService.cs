using StockManagement.App.Services.Base;
using StockManagement.App.Services;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Contracts
{
    public interface IProductDataService
    {
        Task<List<ProductListViewModel>> GetAllProducts();
        Task<ApiResponse<ProductViewModel>> GetProductById(int id);
        Task<ApiResponse<ProductDetailsViewModel>> GetProductDetailsById(int id);
        Task<ApiResponse<string>> UpdateProduct(ProductViewModel productViewModel);
        Task<ApiResponse<ProductDto>> CreateProduct(ProductViewModel productViewModel);
    }
}
