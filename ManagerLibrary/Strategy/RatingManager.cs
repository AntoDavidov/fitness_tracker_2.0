using ExerciseLibrary.Rating;
using IRepositories;
using ManagerLibrary.Exceptions;
using System.Collections.Generic;

namespace ManagerLibrary
{
    public class RatingManager
    {
        private readonly IRatingRepo _ratingRepo;

        public RatingManager(IRatingRepo ratingRepo)
        {
            _ratingRepo = ratingRepo;
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

        public int GetRatingCount(int workoutId)
        {
            return _ratingRepo.GetRatingCount(workoutId);
        }
    }
}
