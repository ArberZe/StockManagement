using StockManagement.App.ViewModels;

namespace StockManagement.App.Contracts
{
    public interface ICountryDataService
    {
        Task<List<CountryListViewModel>> GetAllCountries();
    }
}
