using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Contracts
{
    public interface IProductDataService
    {
        Task<List<ProductViewModel>> GetAllProducts();
        Task<ProductDetailsViewModel> GetProductById(int id);
        Task<ApiResponse<int>> UpdateProduct(ProductDetailsViewModel productDetailViewModel);
        Task<ApiResponse<ProductDto>> CreateProduct(ProductViewModel productViewModel);
    }
}
