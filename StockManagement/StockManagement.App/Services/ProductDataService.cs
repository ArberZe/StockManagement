using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;
using StockManagement.Application.Features.Products.Commands.CreateProduct;
using StockManagement.Application.Features.Products.Commands.UpdateProduct;
using System.Linq;

namespace StockManagement.App.Services
{
    public class ProductDataService: BaseDataService, IProductDataService
    {
        private readonly IMapper _mapper;
        public ProductDataService(IClient client, 
            IMapper mapper, 
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage, authenticationStateProvider)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductListViewModel>> GetAllProducts()
        {
            var allProducts = await _client.GetAllProductsAsync();
            var mappedProducts = _mapper.Map<ICollection<ProductListViewModel>>(allProducts);
            return mappedProducts.ToList();
        }

        public async Task<ApiResponse<ProductViewModel>> GetProductById(int id)
        {
            try
            {
                ApiResponse<ProductViewModel> apiResponse = new();
                var result = await _client.GetProductByIdAsync(id);
                if (result.Success)
                {
                    apiResponse.Success = true;
                    apiResponse.Data = _mapper.Map<ProductViewModel>(result.Product);
                }
                else
                {
                    apiResponse.Data = null;
                    apiResponse.Message = result.Message;
                }
                return apiResponse;
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<ProductViewModel>(ex);
            }
        }

        public async Task<ApiResponse<ProductDetailsViewModel>> GetProductDetailsById(int id)
        {
            try
            {
                ApiResponse<ProductDetailsViewModel> apiResponse = new();
                var result = await _client.GetProductByIdAsync(id);
                if(result.Success)
                {
                    apiResponse.Success = true;
                    apiResponse.Data = _mapper.Map<ProductDetailsViewModel>(result.Product);
                }
                else
                {
                    apiResponse.Data = null;
                    apiResponse.Message = result.Message;
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<ProductDetailsViewModel>(ex);
            }
            /*var selectedProduct = await _client.GetProductByIdAsync(id);
            var mappedProduct = _mapper.Map<ProductDetailsViewModel>(selectedProduct);
            return mappedProduct;*/
        }

        public async Task<ApiResponse<int>> UpdateProduct(ProductViewModel productViewModel)
        {
            await AddBearerToken();
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
            await AddBearerToken();
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
