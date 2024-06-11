using ExerciseLibrary.Rating;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.ConcreteStrategyClasses
{
    public class RatingCalculator
    {
        private ICalculateRating _ratingStrategy;

        public void SetRatingStrategy(ICalculateRating ratingStrategy)
        {
            _ratingStrategy = ratingStrategy;
        }

        public double Calculate(List<Rating> ratings, int workoutId)
        {
            if (_ratingStrategy == null)
                throw new InvalidOperationException("Strategy not set.");

            return _ratingStrategy.CalculateRating(ratings, workoutId);
        }
    }


}
