using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StockManagement.App.Areas.Identity.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        private readonly Contracts.IAuthenticationService _authService;

        public LoginModel(Contracts.IAuthenticationService authService)
        {
            _authService = authService;
        }


        public class InputModel
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public async Task<IActionResult> OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return LocalRedirect("~/");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    var response = await _authService.Authenticate(Input.Username, Input.Password);
                    if (response.Token != string.Empty)
                    {
                        var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, "DisplayName", "");
                        claimsIdentity.AddClaim(new Claim("Token", response.Token));
                        var principal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        return LocalRedirect("/");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Kombinimi i kredencialeve nuk u gjet, Provoni perseri!";
                    }
                }
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Autentikimi me server deshtoi, ju lutem kontaktoni ekipin zhvillues!";
                return Page();
            }
        }
    }
}
