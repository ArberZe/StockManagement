using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StockManagement.App.Areas.Identity.Pages.Account
{
    public class Logout: PageModel
    {
        private readonly Contracts.IAuthenticationService _authenticationService;
        public Logout(Contracts.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<IActionResult> OnGet()
        {
            await _authenticationService.Logout();
            await HttpContext.SignOutAsync("Cookies");
            return Redirect("~/");
        }
    }
}
