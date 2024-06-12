using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ExerciseLibrary;
using ExerciseLibrary.Rating;
using IRepositories;
using NameLibrary;
using DBLibrary.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DBLibrary
{
    public class RatingDBManager : DBDal, IRatingRepo
    {
        private readonly WorkoutDBManager _workoutDBManager;
        private readonly CustomerDBManager _customerDBManager;

        public RatingDBManager()
        {
            _workoutDBManager = new WorkoutDBManager();
            _customerDBManager = new CustomerDBManager();
        }

        public void AddRating(Rating rating)
        {
            if (rating == null) throw new ArgumentNullException(nameof(rating));

            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = "INSERT INTO Rating (WorkoutId, CustomerId, RatingValue) VALUES (@WorkoutId, @CustomerId, @RatingValue)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@WorkoutId", rating.GetWorkout().GetId());
                        cmd.Parameters.AddWithValue("@CustomerId", rating.GetCustomer().GetId());
                        cmd.Parameters.AddWithValue("@RatingValue", rating.GetRatingValue());

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error adding rating: " + ex.Message);
                throw new ConnectionExceptionSQL("Error adding rating!");
            }
        }

        public List<Rating> GetRatingsByWorkoutId(int workoutId)
        {
            var ratings = new List<Rating>();
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = "SELECT WorkoutId, CustomerId, RatingValue FROM Rating WHERE WorkoutId = @WorkoutId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@WorkoutId", workoutId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int wId = reader.GetInt32(reader.GetOrdinal("WorkoutId"));
                                int cId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
                                int ratingValue = reader.GetInt32(reader.GetOrdinal("RatingValue"));

                                Workouts workout = _workoutDBManager.GetWorkoutById(wId);
                                Customer customer = _customerDBManager.GetCustomerById(cId);

                                if (workout == null || customer == null)
                                {
                                    throw new InvalidOperationException("Workout or Customer not found.");
                                }

                                var rating = new Rating(workout, customer, ratingValue);
                                ratings.Add(rating);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error adding rating: " + ex.Message);
                throw new ConnectionExceptionSQL("Error connection!");
            }
            return ratings;
        }

        public int GetRatingCount(int workoutId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Rating WHERE WorkoutId = @WorkoutId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error fetching rating count: " + ex.Message);
                throw new ConnectionExceptionSQL("Error fetching rating count!");
            }
        }

        public bool RatingExists(int workoutId, int customerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Rating WHERE WorkoutId = @WorkoutId AND CustomerId = @CustomerId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error checking rating existence: " + ex.Message);
                throw new ConnectionExceptionSQL("Error checking rating existence!");
            }
        }
    }
}
