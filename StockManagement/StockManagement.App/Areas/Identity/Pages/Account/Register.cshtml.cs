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
            try
            {
                ReturnUrl = Url.Content("~/identity/account/login");
                if (ModelState.IsValid)
                {
                    if (await _authenticationService.Register(Input.FirstName, Input.LastName, Input.UserName, Input.Email, Input.Password))
                    {
                        TempData["SuccessRegisterMessage"] = "Jeni regjistruar me sukses";
                    }
                }
                return Page();
            }
            catch(Exception ex) {
                TempData["ErrorMessage"] = $"{ex.Message}";
                return Page();
            }

        }

        public class InputModel
        {
            [Required(ErrorMessage = "Shkruani Email-in")]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage ="Shkruani password-in")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Shkruani emrin")]
            public string FirstName { get; set; } = string.Empty;
            
            [Required(ErrorMessage = "Shkruani mbiemrin")]
            public string LastName { get; set; } = string.Empty;
            
            [Required(ErrorMessage = "Shkruani username-in")] 
            public string UserName { get; set; } = string.Empty;

        }
    }
}
