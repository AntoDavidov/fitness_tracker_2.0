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
            Login = new LoginDTO();
        }   
        public void OnGet()
        {
            if(Request.Cookies.ContainsKey(nameof(Login.Email)))
            {
                Login.Email = Request.Cookies[nameof(Login.Email)];
                Login.RememberMe = true;
            }

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
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

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

                HttpContext.Session.SetString(nameof(Login.Email), Login.Email);
                
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
