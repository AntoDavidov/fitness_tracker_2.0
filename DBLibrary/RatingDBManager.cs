using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ExerciseLibrary;
using ExerciseLibrary.Rating;
using IRepositories;
using NameLibrary;


using DBLibrary.Exceptions;

namespace DBLibrary
{
    public class RatingDBManager : DBDal, IRatingRepo
    {
        private  readonly WorkoutDBManager workoutDBManager;
        private readonly CustomerDBManager customerDBManager;

        
        public void AddRating(Rating rating)
        {
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
            catch (Exception ex)
            {
                Console.WriteLine("Error adding rating: " + ex.Message);
            }
        }

        public List<Rating> GetRatingsByWorkoutId(int workoutId)
        {
            List<Rating> ratings = new List<Rating>();
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

                                Workouts workout = workoutDBManager.GetWorkoutById(wId);
                                Customer customer = customerDBManager.GetCustomerById(cId);

                                Rating rating = new Rating(workout, customer, ratingValue);
                                ratings.Add(rating);

                            }
                        }
                    }
                }
            }
            catch
            {
                throw new ConnectionExceptionSQL("Error connection!");
            }
            return ratings;
        }
        public int GetRatingCount(int workoutId) 
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Rating WHERE WorkoutId = @WorkoutId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching rating count: " + ex.Message);
            }
            return count;
        }
        public bool RatingExists(int workoutId, int customerId)
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
    }
}
