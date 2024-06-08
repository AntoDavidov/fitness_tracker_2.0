using ExerciseLibrary.Rating;
using IRepositories;
using System.Collections.Generic;

namespace Unit_Testing.FakeRepo
{
    public class FakeRatingRepo : IRatingRepo
    {
        private readonly List<Rating> ratings = new List<Rating>();

        public void AddRating(Rating rating)
        {
            ratings.Add(rating);
        }

        public List<Rating> GetRatingsByWorkoutId(int workoutId)
        {
            List<Rating> ratingsForWorkout = new List<Rating>();

            foreach (var rating in ratings)
            {
                if (rating.GetWorkoutID() == workoutId)
                {
                    ratingsForWorkout.Add(rating);
                }
            }

            return ratingsForWorkout;
        }

        public int GetRatingCount(int workoutId)
        {
            int count = 0;

            foreach (var rating in ratings)
            {
                if (rating.GetWorkoutID() == workoutId)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
