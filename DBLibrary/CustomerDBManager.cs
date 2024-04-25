using NameLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public class CustomerDBManager : DBDal
    {
        public bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, string level)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string hashedPassword = HashPassword(password);
                    // Insert into User table
                    string insertUserQuery = "INSERT INTO [User] (first_name, last_name, username, [password], email) VALUES (@FirstName, @LastName, @Username, @Password, @Email); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, conn);
                    insertUserCommand.Parameters.AddWithValue("@FirstName", firstName);
                    insertUserCommand.Parameters.AddWithValue("@LastName", lastName);
                    insertUserCommand.Parameters.AddWithValue("@Username", username);
                    insertUserCommand.Parameters.AddWithValue("@Password", hashedPassword);
                    insertUserCommand.Parameters.AddWithValue("@Email", email);
                    int userId = Convert.ToInt32(insertUserCommand.ExecuteScalar());

                    // Insert into Customer table
                    string insertCustomerQuery = "INSERT INTO Customer (user_id, user_weight, member_level) VALUES (@UserId, @UserWeight, @MemberLevel);";
                    SqlCommand insertCustomerCommand = new SqlCommand(insertCustomerQuery, conn);
                    insertCustomerCommand.Parameters.AddWithValue("@UserId", userId);
                    insertCustomerCommand.Parameters.AddWithValue("@UserWeight", weight);
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
                Console.WriteLine($"Verifying credentials for email: {email}");
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string hashedPassword = HashPassword(password);

                    string query = "SELECT u.id, u.first_name, u.last_name, u.username, u.password, u.email, c.user_weight, c.member_level " +
                                   "FROM [User] u " +
                                   "INNER JOIN Customer c ON u.id = c.user_id " +
                                   "WHERE u.email = @Email AND u.password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

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
                            double weight = reader.GetDouble(reader.GetOrdinal("user_weight"));
                            string level = reader.GetString(reader.GetOrdinal("member_level"));

                            // Verify the hashed password from the database
                            bool passwordVerified = VerifyPassword(password, dbPassword);

                            if (passwordVerified)
                            {
                                return new Customer(id, firstName, lastName, username, dbPassword, userEmail, weight, level);
                            }
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
    }
}
