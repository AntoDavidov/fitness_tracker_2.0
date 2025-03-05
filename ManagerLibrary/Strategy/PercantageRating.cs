using IRepositories;
using ExerciseLibrary.Rating;
using System.Collections.Generic;

namespace ManagerLibrary.ConcreteStrategyClasses
{
    public class PercantageRating : ICalculateRating
    {
        public double[] CalculateRating(List<Rating> ratings, int workoutId)
        {
            double[] ratingDistribution = new double[5];

            if (ratings.Count == 0)
            {
                return ratingDistribution;
            }

            foreach (var rating in ratings)
            {
                int ratingValue = rating.GetRatingValue();
                if (ratingValue >= 1 && ratingValue <= 5)
                {
                    ratingDistribution[ratingValue - 1]++;
                }
            }

            int totalRatings = ratings.Count;
            for (int i = 0; i < ratingDistribution.Length; i++)
            {
                ratingDistribution[i] = (ratingDistribution[i] / totalRatings) * 100;
            }

            return ratingDistribution;
        }
    }
}
