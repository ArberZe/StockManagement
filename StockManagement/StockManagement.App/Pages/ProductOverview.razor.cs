﻿using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.ViewModels;


namespace StockManagement.App.Pages
{
    public partial class ProductOverview
    {
        [Inject]
        public IProductDataService ProductDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<ProductListViewModel> Products { get; set; } = new List<ProductListViewModel>();

        protected async override Task OnInitializedAsync()
        {
            Products = await ProductDataService.GetAllProducts();
        }
    }
}
