using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagerLibrary;
using NameLibrary;
using System.Linq;
using ExerciseLibrary;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly WorkoutManager _workoutManager;
        private readonly CustomerManager _customerManager;

        public Workouts Workout { get; set; }
        public int TotalCaloriesBurned { get; private set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public DetailsModel(WorkoutManager workoutManager, CustomerManager customerManager)
        {
            _workoutManager = workoutManager;
            _customerManager = customerManager;
        }

        public IActionResult OnGet(int id)
        {
            Workout = _workoutManager.GetWorkoutById(id);

            if (Workout == null)
            {
                ErrorMessage = "Workout not found.";
            }
            return Page();
        }

        public IActionResult OnPostAddToFavorites()
        {
            var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (customerId == -1)
            {
                ErrorMessage = "User not found.";
                return Page();
            }

            var workout = _workoutManager.GetWorkoutById(Id);
            if (workout == null)
            {
                ErrorMessage = "Workout not found.";
                return Page();
            }

            bool addedSuccessfully = _customerManager.AddWorkoutToFavourites(customerId, Id);
            if (addedSuccessfully)
            {
                SuccessMessage = "Workout added to favorites successfully!";
            }
            else
            {
                ErrorMessage = "Workout is already in your favorites.";
            }

            Workout = workout; 
            return Page();
        }
        public IActionResult OnPostCalculateCalories()
        {
            var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (customerId == -1)
            {
                ErrorMessage = "User not found.";
                return Page();
            }

            var workout = _workoutManager.GetWorkoutById(Id);
            if (workout == null)
            {
                ErrorMessage = "Workout not found.";
                return Page();
            }

            var customer = _customerManager.GetCustomerById(customerId);
            if (customer == null)
            {
                ErrorMessage = "Customer not found.";
                return Page();
            }

            TotalCaloriesBurned = workout.CalculateCaloriesBurnedForTheWholeWorkout(customer);

            Workout = workout;
            return Page();
        }
    }
}
