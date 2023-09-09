using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using StockManagement.App.Contracts;
using StockManagement.App.Services;
using StockManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StockManagement.App.Pages
{
    public partial class CompanyOverview
    {
        [Inject]
        protected ICompanyDataService CompanyDataService { get; set; }

        protected ICollection<CompanyListViewModel> Companies { get; set; } = new List<CompanyListViewModel>();

        protected override async Task OnInitializedAsync()
        {
            Companies = await CompanyDataService.GetAllCompanies();
        }
    }
}
