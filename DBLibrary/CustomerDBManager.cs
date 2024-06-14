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
        public bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, Level level, int age)
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
                    string insertCustomerQuery = "INSERT INTO Customer (user_id, user_weight, member_level, age) VALUES (@UserId, @UserWeight, @MemberLevel, @Age);";
                    SqlCommand insertCustomerCommand = new SqlCommand(insertCustomerQuery, conn);
                    insertCustomerCommand.Parameters.AddWithValue("@UserId", userId);
                    insertCustomerCommand.Parameters.AddWithValue("@UserWeight", Convert.ToDecimal(weight));
                    insertCustomerCommand.Parameters.AddWithValue("@MemberLevel", (int)level);
                    insertCustomerCommand.Parameters.AddWithValue("@Age", age);
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

                    string query = "SELECT u.id, u.first_name, u.last_name, u.username, u.password, u.email, c.user_weight, c.member_level, c.age " +
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
                            Level level = (Level)reader.GetInt32(reader.GetOrdinal("member_level"));
                            int age = reader.GetInt32(reader.GetOrdinal("age"));

                            return new Customer(id, firstName, lastName, username, dbPassword, userEmail, weight, level, age);
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
            }
        }
        public bool RemoveWorkoutFromFavourites(int customerId, int workoutId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM CustomerWorkout WHERE CustomerId = @CustomerId AND WorkoutId = @WorkoutId";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn);
                    deleteCommand.Parameters.AddWithValue("@CustomerId", customerId);
                    deleteCommand.Parameters.AddWithValue("@WorkoutId", workoutId);
                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unable to remove the workout from favorites: {ex}");
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

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = @"SELECT u.id, u.first_name, u.last_name, u.username, u.password, u.email, c.user_weight, c.member_level, c.age
                             FROM [User] u
                             INNER JOIN Customer c ON u.id = c.user_id
                             WHERE c.user_id = @CustomerId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                                string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                                string username = reader.GetString(reader.GetOrdinal("username"));
                                string password = reader.GetString(reader.GetOrdinal("password"));
                                string email = reader.GetString(reader.GetOrdinal("email"));
                                double weight = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("user_weight")));
                                Level level = (Level)reader.GetInt32(reader.GetOrdinal("member_level"));
                                int age = reader.GetInt32(reader.GetOrdinal("age"));

                                customer = new Customer(id, firstName, lastName, username, password, email, weight, level, age);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching customer by ID: " + ex.Message);
            }

            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                string query = @"SELECT u.id, u.first_name, u.last_name, u.username, u.password, u.email, c.user_weight, c.member_level, c.age
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
                            Level level = (Level)reader.GetInt32(reader.GetOrdinal("member_level"));
                            int age = reader.GetInt32(reader.GetOrdinal("age"));

                            Customer customer = new Customer(id, firstName, lastName, username, password, email, weight, level, age);
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
                                Level workoutLevel = (Level)reader.GetInt32(reader.GetOrdinal("workout_level"));

                                Workouts workout = new Workouts(id, name, description, workoutLevel);
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

        public List<Workouts> GetFavoriteWorkoutsByPage(int userId, int pageIndex, int pageSize)
        {
            List<Workouts> workouts = new List<Workouts>();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    string query = @"SELECT w.id, w.Name, w.Description, w.workout_level 
                                     FROM CustomerWorkout fw
                                     JOIN Workout w ON fw.WorkoutId = w.id
                                     WHERE fw.CustomerId = @CustomerId
                                     ORDER BY w.id
                                     OFFSET @Offset ROWS
                                     FETCH NEXT @PageSize ROWS ONLY";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", userId);
                        cmd.Parameters.AddWithValue("@Offset", (pageIndex - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@PageSize", pageSize);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));
                                string description = reader.GetString(reader.GetOrdinal("Description"));
                                Level workoutLevel = (Level)reader.GetInt32(reader.GetOrdinal("workout_level"));

                                // Create a new Workout object and add it to the list
                                Workouts workout = new Workouts(id, name, description, workoutLevel);
                                workouts.Add(workout);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return workouts;
        }

        public int GetTotalFavoriteWorkouts(int userId)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM CustomerWorkout WHERE CustomerId = @CustomerId";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", userId);
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return count;
        }

        public Dictionary<int, List<int>> GetAllCustomerFavoriteWorkouts()
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
                var query = @"SELECT w.id, w.name, w.description, w.workout_level
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
                            Level workoutLevel = (Level)reader.GetInt32(3);

                            result.Add(new Workouts(id, name, description, workoutLevel));
                        }
                    }
                }
            }
            return result;
        }
    }
}
