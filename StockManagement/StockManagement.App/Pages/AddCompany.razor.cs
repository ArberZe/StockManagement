using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.Services;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Pages
{
    [Authorize]
    public partial class AddCompany
    {
        [Inject]
        protected ICompanyDataService CompanyDataService { get; set; }


        [Inject]
        protected ICountryDataService CountryDataService { get; set; }


        [Inject]

        protected NavigationManager NavigationManager { get; set; }

        protected CompanyViewModel CompanyViewModel { get; set; } = new();
        protected ICollection<CountryListViewModel> Countries { get; set; } = new List<CountryListViewModel>();

        protected string Message { get; set; }
        protected string MessageClass { get; set; }
        protected bool isLoading { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Countries = await CountryDataService.GetAllCountries();
        }

        protected async Task HandleValidSubmit()
        {
            isLoading = true;
            var response = await CompanyDataService.CreateCompany(CompanyViewModel);
            HandleResponse(response);
        }

        protected void HandleResponse(ApiResponse<CreateCompanyDto> response)
        {
            if(response.Success)
            {
                isLoading = false;
                Message = "Firma u shtua";
                MessageClass = "alert-success";
                NavigationManager.NavigateTo("/companyoverview");
            }
            else
            {
                isLoading = false;
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;

                MessageClass = "alert-danger";
            }

        }

    }
}
