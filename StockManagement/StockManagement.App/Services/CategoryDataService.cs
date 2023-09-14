using AutoMapper;
using Blazored.LocalStorage;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;
using System.Net.Http;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace StockManagement.App.Services
{
    public class CategoryDataService: BaseDataService, ICategoryDataService
    {
        private readonly IMapper _mapper;
        //private readonly AuthenticationStateProvider _authenticationStateProvider;
        public CategoryDataService(IClient client, 
            IMapper mapper, 
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage, authenticationStateProvider)
        {
            //_authenticationStateProvider = authenticationStateProvider;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            //await AddBearerToken();

            var allCategories = await _client.GetAllCategoriesAsync();
            var mappedCategories = _mapper.Map<ICollection<CategoryViewModel>>(allCategories);
            return mappedCategories.ToList();

        }

        public async Task<List<CategoryDescendingOrderedViewModel>> GetAllCategoriesByCreatedDateDescending()
        {
            //await AddBearerToken();

            var allCategories = await _client.GetAllCategoriesByCreatedDateDescendingAsync();
            var mappedCategories = _mapper.Map<ICollection<CategoryDescendingOrderedViewModel>>(allCategories);
            return mappedCategories.ToList();

        }

        public async Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel)
        {
            await AddBearerToken();

            try
            {
                ApiResponse<CategoryDto> apiResponse = new();
                CreateCategoryCommand createCategoryCommand = _mapper.Map<CreateCategoryCommand>(categoryViewModel);
                var createCategoryCommandResponse = await _client.AddCategoryAsync(createCategoryCommand);
                if (createCategoryCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<CategoryDto>(createCategoryCommandResponse.Category);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach (var error in createCategoryCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CategoryDto>(ex);
            }
        }
    }
}