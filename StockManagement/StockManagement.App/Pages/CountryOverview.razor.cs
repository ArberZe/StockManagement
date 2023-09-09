using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Pages
{
    public partial class CountryOverview
    {
        [Inject]
        protected ICountryDataService CountryDataService { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected ICollection<CountryListViewModel> Countries { get; set; } = new List<CountryListViewModel>();

        protected override async Task OnInitializedAsync()
        {
            Countries = await CountryDataService.GetAllCountries();
        }
    }
}
