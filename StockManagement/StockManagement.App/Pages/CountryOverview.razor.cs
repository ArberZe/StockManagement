using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using StockManagement.App.Contracts;
using StockManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
