using ExerciseLibrary.Rating;
using IRepositories;
using ManagerLibrary.ConcreteStrategyClasses;
using ManagerLibrary.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.Strategy
{
    public class RatingClient
    {
        private readonly RatingCalculator _ratingCalculator;

        public RatingClient()
        {
            _ratingCalculator = new RatingCalculator();
        }

        public void SetRatingStrategy(ICalculateRating ratingStrategy)
        {
            _ratingCalculator.SetRatingStrategy(ratingStrategy);
        }

        public double GetWorkoutRating(List<Rating> ratings, int workoutId)
        {
            return _ratingCalculator.Calculate(ratings, workoutId);
        }
    }

}
