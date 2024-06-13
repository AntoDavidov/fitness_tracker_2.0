using ExerciseLibrary;
using IRepositories;
using System;
using System.Collections.Generic;

namespace ManagerLibrary
{
    public class RecommendationService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly WorkoutManager _workoutManager;
        public RecommendationService(ICustomerRepo customerRepo, WorkoutManager workoutManager)
        {
            _customerRepo = customerRepo;
            _workoutManager = workoutManager;
        }

        public List<Workouts> GetRecommendedWorkouts(int customerId)
        {
            var customerFavorites = _customerRepo.GetAllCustomerFavoriteWorkouts();

            if (!customerFavorites.ContainsKey(customerId) || customerFavorites[customerId].Count == 0)
                return GetTopRatedWorkouts();

            var targetCustomerFavorites = customerFavorites[customerId];

            var recommendedWorkoutIds = new List<int>();

            foreach (var kvp in customerFavorites)
            {
                if (kvp.Key != customerId)
                {
                    foreach (var workoutId in kvp.Value)
                    {
                        if (!targetCustomerFavorites.Contains(workoutId) && !recommendedWorkoutIds.Contains(workoutId))
                        {
                            recommendedWorkoutIds.Add(workoutId);
                        }
                    }
                }
            }

            
            return _customerRepo.GetWorkoutsByIds(recommendedWorkoutIds);
        }
        private List<Workouts> GetTopRatedWorkouts()
        {
            return _workoutManager.GetTopRatedWorkouts(4);
        }
        
    }
}
