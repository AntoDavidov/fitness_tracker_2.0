using ExerciseLibrary;
using ManagerLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    [Authorize]
    public class ApplicationModel : PageModel
    {
        private readonly ExerciseManager _exerciseManager;
        private readonly WorkoutManager _workoutManager;
        private readonly CustomerManager _customerManager;

        public List<Workouts> Workouts { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public string SearchLevel { get; private set; }

        public ApplicationModel(ExerciseManager exerciseManager, WorkoutManager workoutManager, CustomerManager customerManager)
        {
            _exerciseManager = exerciseManager;
            _workoutManager = workoutManager;
            _customerManager = customerManager;
        }

        public void OnGet(int pageIndex = 1, string searchLevel = "All")
        {
            const int pageSize = 8; // Display 8 workouts per page
            var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
            var user = _customerManager.GetCustomerById(customerId);
            int userLevel = (int)user.GetLevel();

            bool includeLevel = searchLevel == "UserLevel";
            int? level = includeLevel ? userLevel : (searchLevel == "OtherLevels" ? userLevel : (int?)null);

            TotalPages = (int)Math.Ceiling(_workoutManager.GetFilteredWorkoutsCount(level, includeLevel) / (double)pageSize);

            CurrentPage = pageIndex;
            SearchLevel = searchLevel;
            Workouts = _workoutManager.GetFilteredWorkouts(level, includeLevel, pageIndex, pageSize);
        }

    }
}
