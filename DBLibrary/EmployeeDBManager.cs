using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NameLibrary;

namespace DBLibrary
{
    public class EmployeeDBManager
    {
        private string connectionString;

        public EmployeeDBManager()
        {
            connectionString = "Server=mssqlstud.fhict.local;Database=dbi530206_fitnestrak;User Id=dbi530206_fitnestrak;Password=1234;";
        }
        public bool AddEmployeeToDB(Employee employee)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert into User table
                    string insertUserQuery = "INSERT INTO [User] (first_name, last_name, username, [password], email) VALUES (@FirstName, @LastName, @Username, @Password, @Email); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, conn);
                    insertUserCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    insertUserCommand.Parameters.AddWithValue("@LastName", employee.LastName);
                    insertUserCommand.Parameters.AddWithValue("@Username", employee.UserName);
                    insertUserCommand.Parameters.AddWithValue("@Password", employee.Password);
                    insertUserCommand.Parameters.AddWithValue("@Email", employee.Email);
                    int userId = Convert.ToInt32(insertUserCommand.ExecuteScalar());

                    // Insert into Employee table
                    string insertEmployeeQuery = "INSERT INTO Employee (user_id, role) VALUES (@UserId, @Role);";
                    SqlCommand insertEmployeeCommand = new SqlCommand(insertEmployeeQuery, conn);
                    insertEmployeeCommand.Parameters.AddWithValue("@UserId", userId);
                    insertEmployeeCommand.Parameters.AddWithValue("@Role", employee.Role());
                    insertEmployeeCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

        }
        public bool AddCustomerToDB(Customer customer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert into User table
                    string insertUserQuery = "INSERT INTO [User] (first_name, last_name, username, [password], email) VALUES (@FirstName, @LastName, @Username, @Password, @Email); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, conn);
                    insertUserCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    insertUserCommand.Parameters.AddWithValue("@LastName", customer.LastName);
                    insertUserCommand.Parameters.AddWithValue("@Username", customer.UserName);
                    insertUserCommand.Parameters.AddWithValue("@Password", customer.Password);
                    insertUserCommand.Parameters.AddWithValue("@Email", customer.Email);
                    int userId = Convert.ToInt32(insertUserCommand.ExecuteScalar());

                    // Insert into Customer table
                    string insertCustomerQuery = "INSERT INTO Customer (user_id, user_weight, member_level) VALUES (@UserId, @UserWeight, @MemberLevel);";
                    SqlCommand insertCustomerCommand = new SqlCommand(insertCustomerQuery, conn);
                    insertCustomerCommand.Parameters.AddWithValue("@UserId", userId);
                    insertCustomerCommand.Parameters.AddWithValue("@UserWeight", customer.Weight);
                    insertCustomerCommand.Parameters.AddWithValue("@MemberLevel", customer.Level);
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

        //public List<Employee> GetAllEmployeesFromDB()
        //{
        //    List<Employee> employees = new List<Employee>();

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        string query = "SELECT * FROM Employee";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    int id = reader.GetInt32(reader.GetOrdinal("id"));
        //                    string firstName = reader.GetString(reader.GetOrdinal("firstName"));
        //                    string lastName = reader.GetString(reader.GetOrdinal("lastName"));
        //                    string username = reader.GetString(reader.GetOrdinal("username"));
        //                    string password = reader.GetString(reader.GetOrdinal("password"));
        //                    string email = reader.GetString(reader.GetOrdinal("email"));
        //                    string role = reader.GetString(reader.GetOrdinal("role"));

        //                    Employee employee = new Employee(id, firstName, lastName, username, password, email, role);
        //                    employees.Add(employee);
        //                }
        //            }
        //        }
        //    }

        //    return employees;
        //}
        public bool VerifyUserCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM [User] WHERE username = @Username AND [password] = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verifying user credentials: " + ex.Message);
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

                    // Query the customer table to check if the user exists
                    string query = "SELECT COUNT(*) FROM [User] WHERE email = @email AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // If count > 0, the user exists in the customer table
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error verifying user credentials: " + ex.Message);
                return false;
            }
        }
        public bool DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "DELETE from Employee where id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
