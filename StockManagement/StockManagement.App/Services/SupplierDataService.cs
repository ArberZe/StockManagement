using AutoMapper;
using Blazored.LocalStorage;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Services
{
    public class SupplierDataService: BaseDataService, ISupplierDataService
    {
        private readonly IMapper _mapper;
        public SupplierDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<SupplierListViewModel>> GetAllSuppliers()
        {
            //await AddBearerToken();

            var allSuppliers = await _client.GetAllSuppliersAsync();
            var mappedSuppliers = _mapper.Map<ICollection<SupplierListViewModel>>(allSuppliers);
            return mappedSuppliers.ToList();
        }
    }
}
