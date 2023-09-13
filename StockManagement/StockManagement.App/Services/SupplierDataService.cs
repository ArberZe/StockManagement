using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Services
{
    public class SupplierDataService: BaseDataService, ISupplierDataService
    {
        private readonly IMapper _mapper;
        public SupplierDataService(IClient client, 
            IMapper mapper, 
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage, authenticationStateProvider)
        {
            _mapper = mapper;
        }

        public async Task<List<SupplierListViewModel>> GetAllSuppliers()
        {
            await AddBearerToken();

            var allSuppliers = await _client.GetAllSuppliersAsync();
            var mappedSuppliers = _mapper.Map<ICollection<SupplierListViewModel>>(allSuppliers);
            return mappedSuppliers.ToList();
        }

        public async Task<ApiResponse<CreateSupplierDto>> CreateSupplier(SupplierViewModel supplierViewModel)
        {
            await AddBearerToken();

            try
            {
                ApiResponse<CreateSupplierDto> apiResponse = new();
                CreateSupplierCommand createSupplierCommand = _mapper.Map<CreateSupplierCommand>(supplierViewModel);
                var createProductCommandResponse = await _client.AddSupplierAsync(createSupplierCommand);
                if (createProductCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<CreateSupplierDto>(createProductCommandResponse.Supplier);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach (var error in createProductCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CreateSupplierDto>(ex);
            }
        }
    }
}
