using ExerciseLibrary.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IRatingRepo
    {
        void AddRating(Rating rating);
        List<Rating> GetRatingsByWorkoutId(int workoutId);
        int GetRatingCount(int workoutId);
        bool RatingExists(int workoutId, int customerId);
    }
}
