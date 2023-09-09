using AutoMapper;
using Blazored.LocalStorage;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;
using StockManagement.Application.Features.Products.Commands.UpdateProduct;
using System.Linq;

namespace StockManagement.App.Services
{
    public class ProductDataService: BaseDataService, IProductDataService
    {
        private readonly IMapper _mapper;
        public ProductDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductListViewModel>> GetAllProducts()
        {
            var allProducts = await _client.GetAllProductsAsync();
            var mappedProducts = _mapper.Map<ICollection<ProductListViewModel>>(allProducts);
            return mappedProducts.ToList();
        }

        public async Task<ProductViewModel> GetProductById(int id)
        {
            var selectedProduct = await _client.GetProductByIdAsync(id);
            var mappedProduct = _mapper.Map<ProductViewModel>(selectedProduct);
            return mappedProduct;
        }

        public async Task<ProductDetailsViewModel> GetProductDetailsById(int id)
        {
            var selectedProduct = await _client.GetProductByIdAsync(id);
            var mappedProduct = _mapper.Map<ProductDetailsViewModel>(selectedProduct);
            return mappedProduct;
        }

        public async Task<ApiResponse<int>> UpdateProduct(ProductViewModel productViewModel)
        {
            try
            {
                UpdateProductCommand updateProductCommand = _mapper.Map<UpdateProductCommand>(productViewModel);
                await _client.UpdateProductAsync(updateProductCommand);
                return new ApiResponse<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<ProductDto>> CreateProduct(ProductViewModel productViewModel)
        {
            try
            {
                ApiResponse<ProductDto> apiResponse = new();
                CreateProductCommand createProductCommand = _mapper.Map<CreateProductCommand>(productViewModel);
                var createProductCommandResponse = await _client.AddProductAsync(createProductCommand);
                if (createProductCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<ProductDto>(createProductCommandResponse.Product);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach(var error in createProductCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }catch(ApiException ex)
            {
                return ConvertApiExceptions<ProductDto>(ex);
            }
        }
    }
}
