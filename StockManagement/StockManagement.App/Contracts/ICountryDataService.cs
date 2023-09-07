using StockManagement.App.Services;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Contracts
{
    public interface ICountryDataService
    {
        Task<List<CountryListViewModel>> GetAllCountries();
        Task<ApiResponse<CreateCountryDto>> CreateCountry(CountryViewModel countryViewModel);
    }
}
