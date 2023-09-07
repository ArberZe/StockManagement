using AutoMapper;
using Blazored.LocalStorage;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Services
{
    public class CountryDataService: BaseDataService, ICountryDataService
    {
        private readonly IMapper _mapper;
        public CountryDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CountryListViewModel>> GetAllCountries()
        {
            //await AddBearerToken();

            var allCountries = await _client.GetAllCountriesAsync();
            var mappedCountries = _mapper.Map<ICollection<CountryListViewModel>>(allCountries);
            return mappedCountries.ToList();

        }
    }
}
