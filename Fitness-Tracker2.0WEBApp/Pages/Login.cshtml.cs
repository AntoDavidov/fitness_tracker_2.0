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
        private readonly CustomerManager manager;
        [BindProperty]
        public LoginDTO Login { get; set; }

        public LoginModel(CustomerManager manager)
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

            Customer customer = manager.VerifyLogin(Login);

            if (customer != null)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Email, customer.GetEmail()),
                new Claim(ClaimTypes.Name, customer.GetUsername()),
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
