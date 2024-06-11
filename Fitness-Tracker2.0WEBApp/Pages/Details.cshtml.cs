using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagerLibrary;
using NameLibrary;
using System.Linq;
using ExerciseLibrary;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ManagerLibrary.ConcreteStrategyClasses;
using ManagerLibrary.Exceptions;
using System.ComponentModel.DataAnnotations;
using ExerciseLibrary.Rating;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly WorkoutManager _workoutManager;
        private readonly CustomerManager _customerManager;
        private readonly RatingManager _ratingManager;

        public Workouts Workout { get; set; }
        public int TotalCaloriesBurned { get; private set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public bool HasAlreadyRated { get; private set; }
        public double CalculatedRating { get; set; }
        public int RatingCount { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Workout ID is required.")]
        public int Id { get; set; }

        [BindProperty]
        [Range(1, 5, ErrorMessage = "Rating value must be between 1 and 5.")]
        public int RatingValue { get; set; }

        public DetailsModel(WorkoutManager workoutManager, CustomerManager customerManager, RatingManager ratingManager)
        {
            _workoutManager = workoutManager;
            _customerManager = customerManager;
            _ratingManager = ratingManager;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                Workout = _workoutManager.GetWorkoutById(id);
                if (Workout == null)
                {
                    throw new WorkoutNotFoundException(id);
                }

                var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
                if (customerId == -1)
                {
                    throw new UserNotFoundException(User.FindFirstValue(ClaimTypes.Email));
                }

                HasAlreadyRated = _ratingManager.GetRatingsByWorkoutId(id).Any(r => r.GetCustomer().GetId() == customerId);

                _ratingManager.SetRatingStrategy(new AverageRating());

                CalculatedRating = _ratingManager.GetCalculatedRating(id);
                RatingCount = _ratingManager.GetRatingCount(id);
            }
            catch (WorkoutNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (UserNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }
            return Page();
        }

        public IActionResult OnPostAddToFavorites()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input.";
                return Page();
            }

            try
            {
                var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
                if (customerId == -1)
                {
                    throw new UserNotFoundException(User.FindFirstValue(ClaimTypes.Email));
                }

                var workout = _workoutManager.GetWorkoutById(Id);
                if (workout == null)
                {
                    throw new WorkoutNotFoundException(Id);
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
            }
            catch (UserNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (WorkoutNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }

        public IActionResult OnPostCalculateCalories()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input.";
                return Page();
            }

            try
            {
                var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
                if (customerId == -1)
                {
                    throw new UserNotFoundException(User.FindFirstValue(ClaimTypes.Email));
                }

                var workout = _workoutManager.GetWorkoutById(Id);
                if (workout == null)
                {
                    throw new WorkoutNotFoundException(Id);
                }

                var customer = _customerManager.GetCustomerById(customerId);
                if (customer == null)
                {
                    throw new UserNotFoundException(User.FindFirstValue(ClaimTypes.Email));
                }

                TotalCaloriesBurned = workout.CalculateCaloriesBurnedForTheWholeWorkout(customer);

                Workout = workout;
            }
            catch (UserNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (WorkoutNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }

        public IActionResult OnPostAddRating()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input.";
                return Page();
            }

            try
            {
                var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
                if (customerId == -1)
                {
                    throw new UserNotFoundException(User.FindFirstValue(ClaimTypes.Email));
                }

                var workout = _workoutManager.GetWorkoutById(Id);
                if (workout == null)
                {
                    throw new WorkoutNotFoundException(Id);
                }

                var customer = _customerManager.GetCustomerById(customerId);
                if (customer == null)
                {
                    throw new UserNotFoundException(User.FindFirstValue(ClaimTypes.Email));
                }

                _ratingManager.AddRating(new Rating(workout, customer, RatingValue));
                SuccessMessage = "Rating added successfully!";

                _ratingManager.SetRatingStrategy(new AverageRating());
                CalculatedRating = _ratingManager.GetCalculatedRating(Id);

                Workout = workout;
            }
            catch (UserNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (WorkoutNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (RatingAlreadyExistsException ex)
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }
    }
}
