using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;
using StockManagement.App.Services;
using Microsoft.AspNetCore.Authorization;

namespace StockManagement.App.Pages
{
    [Authorize]
    public partial class AddCategory
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CategoryViewModel CategoryViewModel { get; set; }
        public string Message { get; set; }
        private string MessageClass { get; set; } = String.Empty;

        protected override void OnInitialized()
        {
            CategoryViewModel = new CategoryViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            await base.OnInitializedAsync();
            //await base.OnAfterRenderAsync();
            var response = await CategoryDataService.CreateCategory(CategoryViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<CategoryDto> response)
        {
            if (response.Success)
            {
                Message = "Kategoria u shtua!";
                MessageClass = "alert-success";
                NavigationManager.NavigateTo("/categoryoverview");
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
