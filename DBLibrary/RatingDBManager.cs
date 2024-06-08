using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ExerciseLibrary;
using ExerciseLibrary.Rating;
using IRepositories;

namespace DBLibrary
{
    public class RatingDBManager : DBDal, IRatingRepo
    {
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
                        cmd.Parameters.AddWithValue("@WorkoutId", rating.GetWorkoutID());
                        cmd.Parameters.AddWithValue("@CustomerId", rating.GetCustomerID());
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

                                Rating rating = new Rating(wId, cId, ratingValue);
                                ratings.Add(rating);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching ratings: " + ex.Message);
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
    }
}
