using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.Services;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Pages
{
    public partial class AddProduct
    {
        [Inject]
        public IProductDataService ProductDataService { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ProductListViewModel ProductViewModel { get; set; } 
        public string Message { get; set; }
        private string MessageClass { get; set; } = String.Empty;

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        protected override void OnInitialized()
        {
            ProductViewModel = new ProductListViewModel();
        }
        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategories();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await ProductDataService.CreateProduct(ProductViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<ProductDto> response)
        {
            if (response.Success)
            {
                Message = "Produkti u shtua!";
                MessageClass = "alert-success";
                NavigationManager.NavigateTo("/productoverview");
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
