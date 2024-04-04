using DBLibrary;
using ManagerLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NameLibrary;
using System.Security.Claims;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly EmployeeManager manager;
        [BindProperty]
        public LoginDTO Login { get; set; }

        public LoginModel(EmployeeManager manager)
        {
            this.manager = manager;
        }   
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If model state is not valid, return to the login page
                return Page();
            }

            if (manager.VerifyLogin(Login))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, Login.Email),
                };
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Page();
            }
        }
    }
}
