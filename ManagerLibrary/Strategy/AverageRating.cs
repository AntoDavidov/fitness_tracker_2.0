using IRepositories;
using ExerciseLibrary.Rating;
using System.Collections.Generic;

namespace ManagerLibrary.ConcreteStrategyClasses
{
    public class AverageRating : ICalculateRating
    {
        public double[] CalculateRating(List<Rating> ratings, int workoutId)
        {
            double[] ratingDistribution = new double[5];

            if (ratings.Count == 0)
            {
                return ratingDistribution;
            }

            int totalRating = 0;

            foreach (var rating in ratings)
            {
                totalRating += rating.GetRatingValue();
            }

            double averageRating = (double)totalRating / ratings.Count;
            ratingDistribution[0] = averageRating;

            return ratingDistribution;
        }
    }
}
