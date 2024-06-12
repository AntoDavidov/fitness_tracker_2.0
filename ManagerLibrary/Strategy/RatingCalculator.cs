using ExerciseLibrary.Rating;
using IRepositories;
using System.Collections.Generic;

namespace ManagerLibrary.Strategy
{
    public class RatingCalculator
    {
        private ICalculateRating _ratingStrategy;

        public void SetRatingStrategy(ICalculateRating ratingStrategy)
        {
            _ratingStrategy = ratingStrategy;
        }

        public double[] Calculate(List<Rating> ratings, int workoutId)
        {
            if (_ratingStrategy == null)
            {
                throw new InvalidOperationException("Rating strategy is not set.");
            }
            return _ratingStrategy.CalculateRating(ratings, workoutId);
        }
    }
}
