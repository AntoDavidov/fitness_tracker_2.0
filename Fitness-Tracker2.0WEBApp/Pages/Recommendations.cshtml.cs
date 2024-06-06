using ExerciseLibrary;
using ManagerLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    public class RecommendationsModel : PageModel
    {
        private RecommendationService recommendationService;
        private readonly CustomerManager _customerManager;

        public List<Workouts> RecommendedWorkouts { get; private set; }

        public RecommendationsModel(CustomerManager customermanager, RecommendationService recommendationService)
        {
            this._customerManager = customermanager;
            this.recommendationService = recommendationService;
            RecommendedWorkouts = new List<Workouts>();
        }

        public void OnGet()
        {
            var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (customerId != -1)
            {
                RecommendedWorkouts = recommendationService.GetRecommendedWorkouts(customerId);
            }
            else
            {
                RecommendedWorkouts = new List<Workouts> { };
            }
        }
    }
}
