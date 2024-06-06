using ExerciseLibrary;
using ManagerLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NameLibrary;
using System.Security.Claims;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly WorkoutManager _workoutManager;
        private readonly CustomerManager _customerManager;

        public LoginDTO LoginDTO { get; set; }
        public int WorkoutsCompleted { get; set; }
        public int FavoriteWorkoutsCount { get; set; }
        public List<string> RecentActivities { get; set; }
        public string MotivationalQuote { get; set; }

        public IndexModel(ILogger<IndexModel> logger, CustomerManager customerManager, WorkoutManager workoutManager)
        {
            _logger = logger;
            _customerManager = customerManager;
            _workoutManager = workoutManager;
        }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
                FavoriteWorkoutsCount = _customerManager.GetFavoriteWorkouts(customerId).Count;
                RecentActivities = new List<string> { "Completed Workout 1", "Added Workout 2 to favorites" }; // Example activities
            }

            MotivationalQuote = "The only bad workout is the one that didn't happen.";
        }
    }
}
