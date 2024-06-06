using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagerLibrary;
using NameLibrary;
using Fitness_Tracker2._0WEBApp.Models;
using System.Collections.Generic;
using ExerciseLibrary;

namespace Fitness_Tracker2._0WEBApp.Pages
{
    public class WorkoutProgressModel : PageModel
    {
        private readonly WorkoutManager _workoutManager;
        private readonly CustomerManager _customerManager;

        public Workouts Workout { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; }
        public string ErrorMessage { get; set; }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public List<int> CompletedExercises { get; set; }

        public WorkoutProgressModel(WorkoutManager workoutManager, CustomerManager customerManager)
        {
            _workoutManager = workoutManager;
            _customerManager = customerManager;
            Exercises = new List<ExerciseViewModel>();
        }

        public IActionResult OnGet(int id)
        {
            Id = id;
            Workout = _workoutManager.GetWorkoutById(id);

            if (Workout == null)
            {
                ErrorMessage = "Workout not found.";
                return Page();
            }

            var customerId = GetCustomerId();
            var completedExerciseIds = _customerManager.GetCompletedExercises(customerId, id);

            foreach (var exercise in _workoutManager.GetCurrentWorkoutExercises(Workout))
            {
                var exerciseViewModel = new ExerciseViewModel(exercise.GetId(), exercise.ToString())
                {
                    IsCompleted = completedExerciseIds.Contains(exercise.GetId())
                };
                Exercises.Add(exerciseViewModel);
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var customerId = GetCustomerId();

            // Mark exercises as completed
            foreach (var exerciseId in CompletedExercises)
            {
                _customerManager.MarkExerciseAsCompleted(customerId, Id, exerciseId);
            }

            // Unmark exercises not completed
            foreach (var exercise in Exercises)
            {
                if (!CompletedExercises.Contains(exercise.Id))
                {
                    _customerManager.UnmarkExerciseAsCompleted(customerId, Id, exercise.Id);
                }
            }

            return RedirectToPage(new { id = Id });
        }

        private int GetCustomerId()
        {
            // Assuming the user email is stored in User.Identity.Name
            var email = User.Identity.Name;
            return _customerManager.GetCustomerIdByEmail(email);
        }
    }
}
