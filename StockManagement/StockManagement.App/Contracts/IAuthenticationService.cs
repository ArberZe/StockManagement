using StockManagement.App.Services;

namespace StockManagement.App.Contracts
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(string email, string password);
        Task<bool> Register(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
    }
}
