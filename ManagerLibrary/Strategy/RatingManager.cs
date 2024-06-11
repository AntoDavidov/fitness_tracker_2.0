using ExerciseLibrary.Rating;
using IRepositories;
using System;
using System.Collections.Generic;
using ManagerLibrary.Exceptions;
using ManagerLibrary.Strategy;

namespace ManagerLibrary
{
    public class RatingManager
    {
        private readonly IRatingRepo _ratingRepo;
        private RatingClient _ratingClient;

        public RatingManager(IRatingRepo ratingRepo)
        {
            _ratingRepo = ratingRepo;
            _ratingClient = new RatingClient();
        }

        public void SetRatingStrategy(ICalculateRating ratingStrategy)
        {
            _ratingClient.SetRatingStrategy(ratingStrategy);
        }

        public void AddRating(Rating rating)
        {
            if (_ratingRepo.RatingExists(rating.GetWorkout().GetId(), rating.GetCustomer().GetId()))
            {
                throw new RatingAlreadyExistsException(rating.GetWorkout().GetId(), rating.GetCustomer().GetId());
            }
            _ratingRepo.AddRating(rating);
        }

        public List<Rating> GetRatingsByWorkoutId(int workoutId)
        {
            return _ratingRepo.GetRatingsByWorkoutId(workoutId);
        }

        public double GetCalculatedRating(int workoutId)
        {
            var ratings = _ratingRepo.GetRatingsByWorkoutId(workoutId);
            return _ratingClient.GetWorkoutRating(ratings, workoutId);
        }

        public int GetRatingCount(int workoutId)
        {
            return _ratingRepo.GetRatingCount(workoutId);
        }
    }
}
