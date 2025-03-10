﻿using ExerciseLibrary.Rating;
using IRepositories;
using ManagerLibrary.ConcreteStrategyClasses;
using System.Collections.Generic;

namespace ManagerLibrary.Strategy
{
    public class RatingClient
    {
        private readonly RatingCalculator _ratingCalculator;
        private readonly RatingManager _ratingManager;

        public RatingClient(RatingManager ratingManager, RatingCalculator ratingCalculator)
        {
            _ratingManager = ratingManager;
            _ratingCalculator = ratingCalculator;
        }

        public void SetAverageRatingStrategy()
        {
            _ratingCalculator.SetRatingStrategy(new AverageRating());
        }

        public void SetPercentageRatingStrategy()
        {
            _ratingCalculator.SetRatingStrategy(new PercantageRating());
        }

        public double[] GetWorkoutRating(int workoutId)
        {
            var ratings = _ratingManager.GetRatingsByWorkoutId(workoutId);
            return _ratingCalculator.Calculate(ratings, workoutId);
        }

    }
}
