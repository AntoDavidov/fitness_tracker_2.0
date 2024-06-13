using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagerLibrary;
using NameLibrary;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ManagerLibrary.Strategy;
using ManagerLibrary.Exceptions;
using System.ComponentModel.DataAnnotations;
using ExerciseLibrary.Rating;
using ExerciseLibrary;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly WorkoutManager _workoutManager;
        private readonly CustomerManager _customerManager;
        private readonly RatingManager _ratingManager;
        private readonly RatingClient _ratingClient;

        public Workouts Workout { get; set; }
        public int TotalCaloriesBurned { get; private set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public bool HasAlreadyRated { get; private set; }
        public double CalculatedRating { get; set; }
        public int RatingCount { get; set; }
        public double[] RatingPercentages { get; private set; }

        public string SelectedStrategy { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Workout ID is required.")]
        public int Id { get; set; }

        [BindProperty]
        [Range(1, 5, ErrorMessage = "Rating value must be between 1 and 5.")]
        public int RatingValue { get; set; }

        public DetailsModel(WorkoutManager workoutManager, CustomerManager customerManager, RatingManager ratingManager, RatingClient ratingClient)
        {
            _workoutManager = workoutManager;
            _customerManager = customerManager;
            _ratingManager = ratingManager;
            _ratingClient = ratingClient;
            RatingPercentages = new double[5];
            SelectedStrategy = "Average";
        }

        public IActionResult OnGet(int id)
        {
            if (!TryInitialize(id, out var customerId))
            {
                return Page();
            }

            SetRatingStrategyAndRecalculateProperties(id, customerId, SelectedStrategy);
            return Page();
        }

        public IActionResult OnPostSetAverageRating()
        {
            if (!TryInitialize(Id, out var customerId))
            {
                return Page();
            }

            SelectedStrategy = "Average";
            SetRatingStrategyAndRecalculateProperties(Id, customerId, SelectedStrategy);
            return Page();
        }

        public IActionResult OnPostSetPercentageRating()
        {
            if (!TryInitialize(Id, out var customerId))
            {
                return Page();
            }

            SelectedStrategy = "Percentage";
            SetRatingStrategyAndRecalculateProperties(Id, customerId, SelectedStrategy);
            return Page();
        }

        public IActionResult OnPostAddToFavorites()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input.";
                return Page();
            }

            if (!TryInitialize(Id, out var customerId))
            {
                return Page();
            }

            bool addedSuccessfully = _customerManager.AddWorkoutToFavourites(customerId, Id);
            SuccessMessage = addedSuccessfully ? "Workout added to favorites successfully!" : "Workout is already in your favorites.";

            SetRatingStrategyAndRecalculateProperties(Id, customerId, SelectedStrategy);
            return Page();
        }

        public IActionResult OnPostCalculateCalories()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input.";
                return Page();
            }

            if (!TryInitialize(Id, out var customerId))
            {
                return Page();
            }

            var customer = _customerManager.GetCustomerById(customerId);
            if (customer == null)
            {
                ErrorMessage = $"Customer not found for email {User.FindFirstValue(ClaimTypes.Email)}.";
                return Page();
            }

            TotalCaloriesBurned = Workout.CalculateCaloriesBurnedForTheWholeWorkout(customer);

            SetRatingStrategyAndRecalculateProperties(Id, customerId, SelectedStrategy);
            return Page();
        }

        public IActionResult OnPostAddRating()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input.";
                return Page();
            }

            if (!TryInitialize(Id, out var customerId))
            {
                return Page();
            }

            try
            {
                var customer = _customerManager.GetCustomerById(customerId);
                if (customer == null)
                {
                    throw new UserNotFoundException(User.FindFirstValue(ClaimTypes.Email));
                }

                _ratingManager.AddRating(new Rating(Workout, customer, RatingValue));
                SuccessMessage = "Rating added successfully!";

                SetRatingStrategyAndRecalculateProperties(Id, customerId, SelectedStrategy);
            }
            catch (RatingAlreadyExistsException ex)
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }

        private bool TryInitialize(int workoutId, out int customerId)
        {
            try
            {
                Workout = _workoutManager.GetWorkoutById(workoutId);
                if (Workout == null)
                {
                    throw new WorkoutNotFoundException(workoutId);
                }

                customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
                if (customerId == -1)
                {
                    throw new UserNotFoundException(User.FindFirstValue(ClaimTypes.Email));
                }

                return true;
            }
            catch (WorkoutNotFoundException ex)
            {
                ErrorMessage = ex.Message;
                customerId = -1;
                return false;
            }
            catch (UserNotFoundException ex)
            {
                ErrorMessage = ex.Message;
                customerId = -1;
                return false;
            }
        }

        private void SetRatingStrategyAndRecalculateProperties(int workoutId, int customerId, string strategy)
        {
            if (strategy == "Percentage")
            {
                _ratingClient.SetPercentageRatingStrategy();
                RatingPercentages = _ratingClient.GetWorkoutRating(workoutId);
            }
            else if (strategy == "Average")
            {
                _ratingClient.SetAverageRatingStrategy();
                double[] ratings = _ratingClient.GetWorkoutRating(workoutId);
                CalculatedRating = ratings[0];
            }

            RecalculateProperties(workoutId, customerId);
        }

        private void RecalculateProperties(int workoutId, int customerId)
        {
            RatingCount = _ratingManager.GetRatingCount(workoutId);
            HasAlreadyRated = false;
            var ratings = _ratingManager.GetRatingsByWorkoutId(workoutId);
            foreach (var rating in ratings)
            {
                if (rating.GetCustomer().GetId() == customerId)
                {
                    HasAlreadyRated = true;
                    break;
                }
            }
        }
    }
}
