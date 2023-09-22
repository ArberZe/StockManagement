using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StockManagement.App.Pages
{
    public partial class ProductDetails
    {
        [Inject]
        public IProductDataService ProductDataService { get; set; }

        [Parameter]
        public string Id { get; set; }
        public ProductDetailsViewModel? productDetailsViewModel { get; set; } = new();
        public bool isLoading { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public string MessageClass { get; set; } = string.Empty;

        /*        protected async override Task OnInitializedAsync()
                {
                    productDetailsViewModel = await ProductDataService.GetProductDetailsById(int.Parse(Id));
                }*/

        protected async override Task OnInitializedAsync()
        {
            var response = await ProductDataService.GetProductDetailsById(int.Parse(Id));
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<ProductDetailsViewModel> response)
        {
            if (response.Success)
            {
                isLoading = false;
                productDetailsViewModel = response.Data;
            }
            else
            {
                isLoading = false;
                Message = response.Message;
                MessageClass = "alert-danger";
            }
        }
    }
}
