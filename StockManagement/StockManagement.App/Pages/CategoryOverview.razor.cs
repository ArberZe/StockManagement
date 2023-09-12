using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using StockManagement.App.Contracts;
using StockManagement.App.ViewModels;


namespace StockManagement.App.Pages
{
    public partial class CategoryOverview
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Categories = await CategoryDataService.GetAllCategories();
        }
    }
}
