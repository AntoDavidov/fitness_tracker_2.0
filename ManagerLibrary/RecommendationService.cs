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
            // Get the favorite workouts of all customers
            var customerFavorites = _customerRepo.GetCustomerFavoriteWorkouts();

            // If the given customer has no favorite workouts, return an empty list
            if (!customerFavorites.ContainsKey(customerId))
                return new List<Workouts>();

            // Get the favorite workouts of the given customer
            var targetCustomerFavorites = customerFavorites[customerId];

            // Create a list to store recommended workout IDs
            var recommendedWorkoutIds = new List<int>();

            // Loop through all customers' favorite workouts
            foreach (var kvp in customerFavorites)
            {
                // Skip the given customer's workouts
                if (kvp.Key != customerId)
                {
                    // Loop through each workout ID in other customers' favorites
                    foreach (var workoutId in kvp.Value)
                    {
                        // If the given customer doesn't already like this workout and it's not already in the list, add it to the recommendations
                        if (!targetCustomerFavorites.Contains(workoutId) && !recommendedWorkoutIds.Contains(workoutId))
                        {
                            recommendedWorkoutIds.Add(workoutId);
                        }
                    }
                }
            }

            // Get the workout details for the recommended workout IDs and return them
            return _customerRepo.GetWorkoutsByIds(recommendedWorkoutIds);
        }
    }
}
