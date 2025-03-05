using DBLibrary;
using ExerciseLibrary;
using ManagerLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ExerciseManager _workoutManager;
        private readonly CustomerManager _customerManager;

        public Workouts Workout { get; private set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public DetailsModel(ExerciseManager workoutManager, CustomerManager customerManager)
        {
            _workoutManager = workoutManager;
            _customerManager = customerManager;
        }

        public IActionResult OnGet()
        {
            Workout = _workoutManager.GetWorkoutById(Id);
            if (Workout == null)
            {
                ErrorMessage = "The requested workout does not exist.";
                return Page();
            }
            return Page();
        }

        public IActionResult OnPostAddToFavorites()
        {
            int customerId = _customerManager.GetCustomerIdByEmail(HttpContext.User.Identity.Name);

            if (customerId == -1)
            {
                // Customer ID not found
                return RedirectToPage("/Error");
            }

            bool success = _customerManager.AddWorkoutToFavourites(customerId, Id);

            if (success)
            {
                return RedirectToPage(new { Id });
            }
            else
            {
                return Page();
            }
        }
    }
}
