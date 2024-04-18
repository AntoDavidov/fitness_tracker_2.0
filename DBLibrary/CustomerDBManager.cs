using NameLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        public bool VerifyCustomerCredentials(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string hashedPassword = HashPassword(password);

                    string query = "SELECT COUNT(*) FROM [User] WHERE email = @email AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // If count > 0, the user exists in the customer table
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verifying user credentials: " + ex.Message);
                return false;
            }
        }
    }
}
