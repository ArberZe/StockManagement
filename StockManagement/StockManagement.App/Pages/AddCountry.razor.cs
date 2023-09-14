using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.Services;
using StockManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace StockManagement.App.Pages
{
    [Authorize]
    public partial class AddCountry
    {
        [Inject]
        protected ICountryDataService CountryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CountryViewModel CountryViewModel { get; set; } = new CountryViewModel();
        public string Message { get; set; } = string.Empty;
        private string MessageClass { get; set; } = String.Empty;

        protected async Task HandleValidSubmit()
        {
            var response = await CountryDataService.CreateCountry(CountryViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<CreateCountryDto> response)
        {
            if (response.Success)
            {
                Message = "Shteti u shtua!";
                MessageClass = "alert-success";
                NavigationManager.NavigateTo("countryoverview");
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
