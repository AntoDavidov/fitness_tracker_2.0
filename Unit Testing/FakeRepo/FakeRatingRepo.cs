using ExerciseLibrary;
using ExerciseLibrary.Rating;
using IRepositories;
using NameLibrary;
using System.Collections.Generic;

namespace Unit_Testing.FakeRepo
{
    public class FakeRatingRepo : IRatingRepo
    {
        private readonly List<Rating> ratings = new List<Rating>();

        public FakeRatingRepo()
        {
            var workouts = new List<Workouts>
            {
                new Workouts(1, "Workout 1", "Description for Workout 1", Level.Beginner),
                new Workouts(2, "Workout 2", "Description for Workout 2", Level.Intermediate),
                new Workouts(3, "Workout 3", "Description for Workout 3", Level.Advanced)
            };

            var customers = new List<Customer>
            {
                new Customer(1, "John", "Doe", "johndoe", "password", "johndoe@example.com", 70, Level.Beginner, 25),
                new Customer(2, "Jane", "Doe", "janedoe", "password", "janedoe@example.com", 65, Level.Intermediate, 23)
            };

            ratings = new List<Rating>
            {
                new Rating(workouts[0], customers[0], 5),
                new Rating(workouts[0], customers[1], 4),
                new Rating(workouts[1], customers[0], 3),
                new Rating(workouts[1], customers[1], 5),
                new Rating(workouts[2], customers[0], 2),
            };
        }

        public void AddRating(Rating rating)
        {
            ratings.Add(rating);
        }

        public List<Rating> GetRatingsByWorkoutId(int workoutId)
        {
            List<Rating> ratingsForWorkout = new List<Rating>();

            foreach (var rating in ratings)
            {
                if (rating.GetWorkout().GetId() == workoutId)
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
                if (rating.GetWorkout().GetId() == workoutId)
                {
                    count++;
                }
            }

            return count;
        }

        public bool RatingExists(int workoutId, int customerId)
        {
            foreach (var rating in ratings)
            {
                if (rating.GetWorkout().GetId() == workoutId && rating.GetCustomer().GetId() == customerId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
