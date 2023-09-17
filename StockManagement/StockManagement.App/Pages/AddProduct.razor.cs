using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace StockManagement.App.Pages
{
    [Authorize]
    public partial class AddProduct
    {
        [Inject]
        public IProductDataService ProductDataService { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public ICompanyDataService CompanyDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ProductViewModel ProductViewModel { get; set; } 
        public string Message { get; set; }
        private string MessageClass { get; set; } = String.Empty;
        private bool isLoading { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        public IEnumerable<CompanyListViewModel> Companies { get; set; } = new List<CompanyListViewModel>();

        protected override void OnInitialized()
        {
            ProductViewModel = new ProductViewModel();
        }
        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategories();
            Companies = await CompanyDataService.GetAllCompanies();
        }

        protected async Task HandleValidSubmit()
        {
            isLoading = true;
            var response = await ProductDataService.CreateProduct(ProductViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<ProductDto> response)
        {
            if (response.Success)
            {
                isLoading = false;
                Message = "Produkti u shtua!";
                MessageClass = "alert-success";
                NavigationManager.NavigateTo("/productoverview");
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
