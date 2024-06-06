using ExerciseLibrary;
using IRepositories;
using System;
using System.Collections.Generic;

namespace ManagerLibrary
{
    public class RecommendationService
    {
        private readonly ICustomerRepo _customerRepo;

        public RecommendationService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public List<Workouts> GetRecommendedWorkouts(int customerId)
        {
            var customerFavorites = _customerRepo.GetCustomerFavoriteWorkouts();
            if (!customerFavorites.ContainsKey(customerId))
                return new List<Workouts>();

            var targetCustomerFavorites = customerFavorites[customerId];
            var otherCustomerFavorites = new HashSet<int>();

            // Collect other customers' favorite workout IDs
            foreach (var kvp in customerFavorites)
            {
                if (kvp.Key != customerId)
                {
                    foreach (var workoutId in kvp.Value)
                    {
                        if (!targetCustomerFavorites.Contains(workoutId))
                        {
                            otherCustomerFavorites.Add(workoutId);
                        }
                    }
                }
            }

            // Convert the HashSet to a list
            var recommendedWorkoutIds = new List<int>(otherCustomerFavorites);

            return _customerRepo.GetWorkoutsByIds(recommendedWorkoutIds);
        }
    }
}
