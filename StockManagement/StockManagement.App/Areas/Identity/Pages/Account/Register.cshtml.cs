//using Microsoft.AspNetCore.Authentication;
using StockManagement.App.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace StockManagement.App.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            if(ModelState.IsValid)
            {
                await _authenticationService.Register(Input.FirstName, Input.LastName, Input.UserName, Input.Email, Input.Password);
                return LocalRedirect(ReturnUrl);
            }

            return Page();
        }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;

        }
    }
}
