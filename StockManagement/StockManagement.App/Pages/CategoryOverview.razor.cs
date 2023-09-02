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

        public ICollection<CategoryDescendingOrderedViewModel> Categories { get; set; } = new List<CategoryDescendingOrderedViewModel>();

        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategoriesByCreatedDateDescending();
        }
    }
}
