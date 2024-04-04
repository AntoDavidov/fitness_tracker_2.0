using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagerLibrary;
using NameLibrary;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly EmployeeManager employeeManager;
        [BindProperty]
        public Customer Customer { get; set; }
        
        public SignUpModel(EmployeeManager manager)
        {
            employeeManager = manager;
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                employeeManager.AddCustomer(Customer);
                return new RedirectToPageResult("Index");
            }
            return Page();
        }
    }
}
