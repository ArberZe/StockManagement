using Blazored.LocalStorage;
using StockManagement.App.Contracts;
using StockManagement.App.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace StockManagement.App.Services
{
    public class AuthenticationService : BaseDataService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IClient client, 
            ILocalStorageService localStorage, 
            AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage, authenticationStateProvider)
        {

        }

        public async Task<AuthenticationResponse> Authenticate(string email, string password)
        {
            AuthenticationRequest authenticationRequest = new () { Email = email, Password = password };
            var authenticationResponse = await _client.AuthenticateAsync(authenticationRequest);
            return authenticationResponse;
        }

        public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            //await _localStorage.RemoveItemAsync("token");
            _client.HttpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
