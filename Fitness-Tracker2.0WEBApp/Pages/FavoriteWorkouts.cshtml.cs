using ExerciseLibrary;
using ManagerLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NameLibrary;
using System.Collections.Generic;
using System.Security.Claims;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    [Authorize]
    public class FavoriteWorkoutsModel : PageModel
    {
        private readonly CustomerManager _customerManager;
        public List<Workouts> FavoriteWorkouts { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }

        public FavoriteWorkoutsModel(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public void OnGet(int pageIndex = 1)
        {
            const int pageSize = 8; // Display 8 workouts per page
            var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
            int totalFavoriteWorkoutsCount = _customerManager.GetTotalFavoriteWorkoutsCount(customerId);
            TotalPages = (int)Math.Ceiling(totalFavoriteWorkoutsCount / (double)pageSize);

            CurrentPage = pageIndex;
            FavoriteWorkouts = _customerManager.GetFavoriteWorkoutsByPage(customerId, pageIndex, pageSize);
        }
    }
}
