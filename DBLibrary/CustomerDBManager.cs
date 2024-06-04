using NameLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IRepositories;

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

                    string query = "SELECT user_id FROM Customer WHERE user_id = (SELECT user_id FROM [User] WHERE email = @Email);";
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
    }
}
