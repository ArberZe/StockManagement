using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.ViewModels;


namespace StockManagement.App.Pages
{
    [Authorize]
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
