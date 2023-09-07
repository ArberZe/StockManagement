using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using StockManagement.App.Contracts;
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
        public ProductDetailsViewModel productDetailsViewModel { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            productDetailsViewModel = await ProductDataService.GetProductDetailsById(int.Parse(Id));
        }
    }
}
