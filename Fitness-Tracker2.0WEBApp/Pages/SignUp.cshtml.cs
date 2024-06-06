using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagerLibrary;
using NameLibrary;
using ManagerLibrary.Exceptions;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly CustomerManager _manager;
        [BindProperty]
        public SignupDTO SignupDTO { get; set; }

        public bool SignUpSuccessfull { get; set; }

        public SignUpModel(CustomerManager manager)
        {
            _manager = manager;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _manager.AddCustomer(
                        SignupDTO.FirstName,
                        SignupDTO.LastName,
                        SignupDTO.UserName,
                        SignupDTO.Password,
                        SignupDTO.Email,
                        SignupDTO.Weight,
                        SignupDTO.Level
                    );

                    SignUpSuccessfull = true;
                    return Page();
                }
                catch (DuplicateUsernameException)
                {
                    ModelState.AddModelError("SignupDTO.UserName", "Username already exists.");
                }
                catch (DuplicateEmailException)
                {
                    ModelState.AddModelError("SignupDTO.Email", "Email already exists.");
                }
                return Page();
            }
            return Page();
        }
    }
}
