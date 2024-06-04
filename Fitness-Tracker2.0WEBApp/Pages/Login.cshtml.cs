using DBLibrary;
using ManagerLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NameLibrary;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly CustomerManager _manager;
        [BindProperty]
        public LoginDTO Login { get; set; }

        public LoginModel(CustomerManager manager)
        {
            _manager = manager;
            Login = new LoginDTO();
        }

        public void OnGet()
        {
            if (Request.Cookies.ContainsKey(nameof(Login.Email)))
            {
                Login.Email = Request.Cookies[nameof(Login.Email)];
                Login.RememberMe = true;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Customer customer = _manager.VerifyCustomerCredentials(Login.Email, Login.Password);

            if (customer != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, customer.GetEmail()),
                    new Claim(ClaimTypes.Name, customer.GetEmail()),  // Use the email as the name claim
                    new Claim("Username", customer.GetUsername())
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

                //HttpContext.Session.SetString(nameof(Login.Email), Login.Email);

                if (Login.RememberMe)
                {
                    CookieOptions cookies = new CookieOptions();
                    cookies.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Append(nameof(Login.Email), Login.Email, cookies);
                }
                else
                {
                    CookieOptions cookies = new CookieOptions();
                    cookies.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Append(nameof(Login.Email), Login.Email, cookies);
                }

                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password. Please try again!");
                return Page();
            }
        }

    }
}
