using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Pages
{
    public partial class EditProduct
    {
        [Inject]
        public IProductDataService ProductDataService { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        public ProductDetailsViewModel ProductDetailViewModel { get; set; } = new ProductDetailsViewModel();
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        public string Message { get; set; }
        private string MessageClass { get; set; } = String.Empty;

        [Parameter]
        public string Id { get; set; }


        protected async override Task OnInitializedAsync()
        {
            ProductDetailViewModel = await ProductDataService.GetProductById(int.Parse(Id));
            Categories = await CategoryDataService.GetAllCategories();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await ProductDataService.UpdateProduct(ProductDetailViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<int> response)
        {
            if (response.Success)
            {
                Message = "Produkti u shtua!";
                MessageClass = "alert-success";
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
