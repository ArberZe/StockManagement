using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.Services;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Pages
{
    [Authorize]
    public partial class AddSupplier
    {
        [Inject]
        protected ISupplierDataService SupplierDataService{ get; set; }

        [Inject]
        protected ICountryDataService CountryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected SupplierViewModel SupplierViewModel { get; set; } = new SupplierViewModel();
        protected ICollection<CountryListViewModel> Countries { get; set; } = new List<CountryListViewModel>();
        protected string Message { get; set; } = string.Empty;
        protected string MessageClass { get; set; } = string.Empty;

        protected async override Task OnInitializedAsync()
        {
            Countries = await CountryDataService.GetAllCountries();
        }
        protected async Task HandleValidSubmit()
        {
            var response = await SupplierDataService.CreateSupplier(SupplierViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<CreateSupplierDto> response)
        {
            if (response.Success)
            {
                Message = "Furnitori u shtua!";
                MessageClass = "alert-success";
                NavigationManager.NavigateTo("supplieroverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;

                MessageClass = "alert-danger";
            }
        }
    }
}
