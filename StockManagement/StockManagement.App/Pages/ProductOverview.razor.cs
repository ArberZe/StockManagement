using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using StockManagement.App.Contracts;
using StockManagement.App.ViewModels;
using System.Net.Http.Headers;

namespace StockManagement.App.Pages
{
    public partial class ProductOverview
    {
        [Inject]
        public IProductDataService ProductDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<ProductListViewModel> Products { get; set; } = new List<ProductListViewModel>();

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Products = await ProductDataService.GetAllProducts();
        }

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected async Task ExportProducts()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var jwtToken = user.FindFirst("Token")?.Value;

                if (!string.IsNullOrEmpty(jwtToken))
                {
                    //var httpClient = HttpClientFactory.CreateClient();
                    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                }
            }

            if (await JSRuntime.InvokeAsync<bool>("confirm", $"Konfirmo per te eksportuar ne file .csv?"))
            {
                var response = await HttpClient.GetAsync($"https://localhost:7017/api/products/export");
                response.EnsureSuccessStatusCode();
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var fileName = $"MyReport{DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)}.csv";
                await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
            }
        }

    }
}
