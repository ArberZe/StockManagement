using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace StockManagement.App.Services.Base
{
    public class BaseDataService
    {
        protected readonly ILocalStorageService _localStorage;

        protected IClient _client;

        protected readonly AuthenticationStateProvider _authenticationStateProvider;


        public BaseDataService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public BaseDataService(IClient client, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        protected ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new ApiResponse<Guid>() { Message = "Validimi deshtoi.", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new ApiResponse<Guid>() { Message = "Nuk u gjet asnje rezultat.", Success = false };
            }
            else
            {
                return new ApiResponse<Guid>() { Message = "Dicka deshtoi, provoni perseri.", ValidationErrors = ex.Response, Success = false };
            }
        }

        protected async Task AddBearerToken()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var jwtToken = user.FindFirst("Token")?.Value;

                if (!string.IsNullOrEmpty(jwtToken))
                {
                    //var httpClient = HttpClientFactory.CreateClient();
                    _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                }
            }
            /*            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                        var user = authState.User;

                        if (user.Identity.IsAuthenticated)
                        {
                            var jwtToken = user.FindFirst("Token")?.Value;

                            if (!string.IsNullOrEmpty(jwtToken))
                            {
                                //var httpClient = HttpClientFactory.CreateClient();
                                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                            }
                        }*/
            /*            var token = ClaimsPrincipal.Current?.Claims.FirstOrDefault(f => f.Type == "Token");
                        if (token != null)
                        {
                            _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"Bearer {token.Value}");

                                *//*.Add(HttpRequestHeader.Authorization.ToString(),
                                $"Bearer {token.Value}");
                        *//*}*/
            /*            if (await _localStorage.ContainKeyAsync("token"))
                            _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
            */
        }
    }
}
