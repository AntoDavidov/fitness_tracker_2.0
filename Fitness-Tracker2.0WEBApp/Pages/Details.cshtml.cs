using DBLibrary;
using ExerciseLibrary;
using ManagerLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ExerciseManager _workoutManager;
        private readonly CustomerManager _customerManager;

        public Workouts Workout { get; private set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

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
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddToFavorites()
        {
            // Get customer ID from session or any other method
            int customerId = _customerManager.GetCustomerIdByEmail(HttpContext.User.Identity.Name);

            if (customerId == -1)
            {
                return RedirectToPage("/Error");
            }

            // Reload the Workout object
            Workout = _workoutManager.GetWorkoutById(Id);
            if (Workout == null)
            {
                return NotFound();
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
