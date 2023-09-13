using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public partial class SupplierOverview
    {
        [Inject]
        public ISupplierDataService SupplierDataService { get; set; }

        public ICollection<SupplierListViewModel> Suppliers { get; set; } = new List<SupplierListViewModel>();

        protected override async Task OnInitializedAsync()
        {
            Suppliers = await SupplierDataService.GetAllSuppliers();
        }
    }
}
