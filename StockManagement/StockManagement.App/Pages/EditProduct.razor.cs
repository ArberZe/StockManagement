using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Pages
{
    [Authorize]
    public partial class EditProduct
    {
        [Inject]
        protected IProductDataService ProductDataService { get; set; }

        [Inject]
        protected ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        protected ICompanyDataService CompanyDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected ProductViewModel ProductViewModel { get; set; } = new();
        protected IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        protected IEnumerable<CompanyListViewModel> Companies { get; set; } = new List<CompanyListViewModel>();
        protected string Message { get; set; } = string.Empty;
        private string MessageClass { get; set; } = String.Empty;

        private bool isLoading { get; set; } = false;

        [Parameter]
        public string? Id { get; set; }


        protected async override Task OnInitializedAsync()
        {

            isLoading = true;
            var result = await ProductDataService.GetProductById(int.Parse(Id));
            HandleGetResponse(result);
            Categories = await CategoryDataService.GetAllCategories();
            Companies = await CompanyDataService.GetAllCompanies();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await ProductDataService.UpdateProduct(ProductViewModel);
            HandleResponse(response);
        }

        private void HandleGetResponse(ApiResponse<ProductViewModel> response)
        {
            if (response.Success)
            {
                isLoading = false;
                ProductViewModel = response.Data;
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;

                MessageClass = "alert-danger";
            }
        }

        private void HandleResponse(ApiResponse<int> response)
        {
            if (response.Success)
            {
                Message = "Produkti u editua!";
                MessageClass = "alert-success";
                NavigationManager.NavigateTo($"/productdetails/{Id}");
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
