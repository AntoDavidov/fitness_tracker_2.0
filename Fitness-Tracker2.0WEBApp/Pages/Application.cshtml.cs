using ExerciseLibrary;
using ManagerLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    public class ApplicationModel : PageModel
    {
        private readonly ExerciseManager _workoutManager;
        public List<Workouts> Workouts { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }

        public ApplicationModel(ExerciseManager workoutManager) 
        { 
            _workoutManager = workoutManager;
        }

        public void OnGet(int pageIndex = 1)
        {
            const int pageSize = 10;
            var totalWorkouts = _workoutManager.GetWorkouts(); // Replace with your method to get all workouts
            TotalPages = (int)Math.Ceiling(totalWorkouts.Count / (double)pageSize);

            CurrentPage = pageIndex;
            Workouts = totalWorkouts
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
