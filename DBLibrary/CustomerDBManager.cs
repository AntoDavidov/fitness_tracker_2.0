using NameLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IRepositories;
using ExerciseLibrary;

namespace DBLibrary
{
    public class CustomerDBManager : DBDal, ICustomerRepo
    {
        public bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, int level)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string insertUserQuery = "INSERT INTO [User] (first_name, last_name, username, [password], email) VALUES (@FirstName, @LastName, @Username, @Password, @Email); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, conn);
                    insertUserCommand.Parameters.AddWithValue("@FirstName", firstName);
                    insertUserCommand.Parameters.AddWithValue("@LastName", lastName);
                    insertUserCommand.Parameters.AddWithValue("@Username", username);
                    insertUserCommand.Parameters.AddWithValue("@Password", password);
                    insertUserCommand.Parameters.AddWithValue("@Email", email);
                    int userId = Convert.ToInt32(insertUserCommand.ExecuteScalar());

                    // Insert into Customer table
                    string insertCustomerQuery = "INSERT INTO Customer (user_id, user_weight, member_level) VALUES (@UserId, @UserWeight, @MemberLevel);";
                    SqlCommand insertCustomerCommand = new SqlCommand(insertCustomerQuery, conn);
                    insertCustomerCommand.Parameters.AddWithValue("@UserId", userId);
                    insertCustomerCommand.Parameters.AddWithValue("@UserWeight", Convert.ToDecimal(weight));
                    insertCustomerCommand.Parameters.AddWithValue("@MemberLevel", level);
                    insertCustomerCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Customer VerifyCustomerCredentials(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = "SELECT u.id, u.first_name, u.last_name, u.username, u.password, u.email, c.user_weight, c.member_level " +
                                   "FROM [User] u " +
                                   "INNER JOIN Customer c ON u.id = c.user_id " +
                                   "WHERE u.email = @Email AND u.password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                            string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                            string username = reader.GetString(reader.GetOrdinal("username"));
                            string dbPassword = reader.GetString(reader.GetOrdinal("password")); // Database hashed password
                            string userEmail = reader.GetString(reader.GetOrdinal("email"));
                            double weight = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("user_weight")));
                            int level = reader.GetInt32(reader.GetOrdinal("member_level"));

                            return new Customer(id, firstName, lastName, username, dbPassword, userEmail, weight, level);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verifying user credentials: " + ex.Message);
            }

            return null;
        }


        public bool AddWorkoutToFavourites(int customerId, int workoutId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM CustomerWorkout WHERE CustomerId = @CustomerId AND WorkoutId = @WorkoutId";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, conn);
                    checkCommand.Parameters.AddWithValue("@CustomerId", customerId);
                    checkCommand.Parameters.AddWithValue("@WorkoutId", workoutId);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count == 0)
                    {
                        string insertQuery = "INSERT INTO CustomerWorkout (CustomerId, WorkoutId) VALUES (@CustomerId, @WorkoutId)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                        insertCommand.Parameters.AddWithValue("@CustomerId", customerId);
                        insertCommand.Parameters.AddWithValue("@WorkoutId", workoutId);
                        insertCommand.ExecuteNonQuery();

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Workout already exists in favorites.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unable to add a workout to favorites: {ex}");
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }

        public int GetCustomerIdByEmail(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = "SELECT user_id FROM Customer WHERE user_id = (SELECT id FROM [User] WHERE email = @Email);";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving customerId by email: " + ex.Message);
            }

            return -1;
        }
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                string query = @"SELECT u.id, u.first_name, u.last_name, u.username, u.password, u.email, c.user_weight, c.member_level
                         FROM [User] u
                         INNER JOIN Customer c ON u.id = c.user_id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                            string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                            string username = reader.GetString(reader.GetOrdinal("username"));
                            string password = reader.GetString(reader.GetOrdinal("password"));
                            string email = reader.GetString(reader.GetOrdinal("email"));
                            double weight = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("user_weight")));
                            int level = reader.GetInt32(reader.GetOrdinal("member_level"));

                            Customer customer = new Customer(id, firstName, lastName, username, password, email, weight, level);
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }
        public List<Workouts> GetFavoriteWorkouts(int customerId)
        {
            List<Workouts> favoriteWorkouts = new List<Workouts>();

            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = @"SELECT w.Id, w.Name, w.Description, w.workout_level 
                                     FROM Workout w
                                     INNER JOIN CustomerWorkout cf ON w.Id = cf.WorkoutId
                                     WHERE cf.CustomerId = @CustomerId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));
                                string description = reader.GetString(reader.GetOrdinal("Description"));
                                string level = reader.GetString(reader.GetOrdinal("workout_level"));

                                Workouts workout = new Workouts(id, name, description, level);
                                favoriteWorkouts.Add(workout);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching favorite workouts: " + ex.Message);
            }

            return favoriteWorkouts;
        }
        public Dictionary<int, List<int>> GetCustomerFavoriteWorkouts()
        {
            var result = new Dictionary<int, List<int>>();
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var query = @"SELECT c.user_id AS CustomerId, cw.WorkoutId AS WorkoutId
                          FROM Customer c
                          INNER JOIN CustomerWorkout cw ON c.user_id = cw.CustomerId;";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int customerId = reader.GetInt32(0);
                            int workoutId = reader.GetInt32(1);
                            if (!result.ContainsKey(customerId))
                            {
                                result[customerId] = new List<int>();
                            }
                            result[customerId].Add(workoutId);
                        }
                    }
                }
            }
            return result;
        }

        public List<Workouts> GetWorkoutsByIds(List<int> workoutIds)
        {
            var result = new List<Workouts>();
            if (workoutIds == null || workoutIds.Count == 0)
                return result;

            using (var conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var query = @"SELECT w.id, w.name, w.description
                          FROM Workout w
                          WHERE w.id IN (" + string.Join(",", workoutIds) + ")";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string description = reader.GetString(2);
                            result.Add(new Workouts(id, name, description));
                        }
                    }
                }
            }
            return result;
        }
        public void MarkExerciseAsCompleted(int customerId, int workoutId, int exerciseId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO CompletedExercises (CustomerId, WorkoutId, ExerciseId) VALUES (@CustomerId, @WorkoutId, @ExerciseId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                cmd.Parameters.AddWithValue("@ExerciseId", exerciseId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UnmarkExerciseAsCompleted(int customerId, int workoutId, int exerciseId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                string query = "DELETE FROM CompletedExercises WHERE CustomerId = @CustomerId AND WorkoutId = @WorkoutId AND ExerciseId = @ExerciseId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                cmd.Parameters.AddWithValue("@ExerciseId", exerciseId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<int> GetCompletedExercises(int customerId, int workoutId)
        {
            List<int> completedExercises = new List<int>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT ExerciseId FROM CompletedExercises WHERE CustomerId = @CustomerId AND WorkoutId = @WorkoutId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        completedExercises.Add(reader.GetInt32(0));
                    }
                }
            }
            return completedExercises;
        }
    }
}
