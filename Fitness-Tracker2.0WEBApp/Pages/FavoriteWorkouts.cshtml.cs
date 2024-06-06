using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagerLibrary;
using NameLibrary;
using System.Collections.Generic;
using ExerciseLibrary;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    [Authorize]
    public class FavoriteWorkoutsModel : PageModel
    {
        private readonly CustomerManager _customerManager;
        public List<Workouts> FavoriteWorkouts { get; private set; }

        public FavoriteWorkoutsModel(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public void OnGet()
        {
            var customerId = _customerManager.GetCustomerIdByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (customerId != -1)
            {
                FavoriteWorkouts = _customerManager.GetFavoriteWorkouts(customerId);
            }
            else
            {
                FavoriteWorkouts =  new List<Workouts> { };
            }
        }
    }
}
