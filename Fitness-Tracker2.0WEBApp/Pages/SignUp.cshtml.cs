using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagerLibrary;
using NameLibrary;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly CustomerManager manager1;
        [BindProperty]
        public SignupDTO SignupDTO { get; set; }

        public bool SignUpSuccessfull { get; set; }
        
        public SignUpModel(CustomerManager manager)
        {
            manager1 = manager;
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                manager1.AddCustomer(SignupDTO);

                SignUpSuccessfull = true;
                return Page();
            }
            return Page();
        }
    }
}
