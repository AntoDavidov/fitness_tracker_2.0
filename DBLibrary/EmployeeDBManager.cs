using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using NameLibrary;
using IRepositories;

namespace DBLibrary
{
    public class EmployeeDBManager : DBDal, IEmployeeRepo
    {
        public EmployeeDBManager()
        {
        }

        public bool AddEmployee(string firstName, string lastName, string username, string hashedPassword, string email, string role)
        {
            try
            {
                if (EmailAlreadyExists(email))
                {
                    throw new Exception();
                }

                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    // Insert into User table
                    string insertUserQuery = "INSERT INTO [User] (first_name, last_name, username, [password], email) VALUES (@FirstName, @LastName, @Username, @Password, @Email); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, conn);
                    insertUserCommand.Parameters.AddWithValue("@FirstName", firstName);
                    insertUserCommand.Parameters.AddWithValue("@LastName", lastName);
                    insertUserCommand.Parameters.AddWithValue("@Username", username);
                    insertUserCommand.Parameters.AddWithValue("@Password", hashedPassword); // Use hashed password
                    insertUserCommand.Parameters.AddWithValue("@Email", email);
                    int userId = Convert.ToInt32(insertUserCommand.ExecuteScalar());

                    // Insert into Employee table
                    string insertEmployeeQuery = "INSERT INTO Employee (user_id, role) VALUES (@UserId, @Role);";
                    SqlCommand insertEmployeeCommand = new SqlCommand(insertEmployeeQuery, conn);
                    insertEmployeeCommand.Parameters.AddWithValue("@UserId", userId);
                    insertEmployeeCommand.Parameters.AddWithValue("@Role", role);
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

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                string query = @"SELECT e.user_id, u.first_name, u.last_name, u.username, u.password, u.email, e.role
                                 FROM Employee e
                                 INNER JOIN [User] u ON e.user_id = u.id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("user_id"));
                            string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                            string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                            string username = reader.GetString(reader.GetOrdinal("username"));
                            string password = reader.GetString(reader.GetOrdinal("password"));
                            string email = reader.GetString(reader.GetOrdinal("email"));
                            string role = reader.GetString(reader.GetOrdinal("role"));

                            Employee employee = new Employee(id, firstName, lastName, username, password, email, role);
                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }

        public Employee GetEmployeeByUsername(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = "SELECT e.user_id, u.first_name, u.last_name, u.username, u.password, u.email, e.role " +
                                   "FROM Employee e INNER JOIN [User] u ON e.user_id = u.user_id " +
                                   "WHERE u.username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("user_id"));
                                string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                                string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                                string password = reader.GetString(reader.GetOrdinal("password"));
                                string email = reader.GetString(reader.GetOrdinal("email"));
                                string role = reader.GetString(reader.GetOrdinal("role"));

                                // Create and return the Employee object
                                return new Employee(id, firstName, lastName, username, password, email, role);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching employee by username: " + ex.Message);
            }

            return null; // Return null if no employee found or an error occurred
        }

        public bool VerifyUserCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
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

        public Employee VerifyEmployeeCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = @"SELECT u.id, u.first_name, u.last_name, u.username, u.password, u.email, e.role 
                             FROM [User] u 
                             INNER JOIN Employee e ON u.id = e.user_id 
                             WHERE u.username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    // Retrieve the user details from the database
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPassword = reader.GetString(reader.GetOrdinal("password"));

                            // Verify the password
                            if (VerifyPassword(password, hashedPassword))
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                                string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                                string email = reader.GetString(reader.GetOrdinal("email"));
                                string role = reader.GetString(reader.GetOrdinal("role"));

                                return new Employee(id, firstName, lastName, username, hashedPassword, email, role);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verifying employee credentials: " + ex.Message);
            }
            return null; // Return null if credentials are incorrect or an error occurs
        }


        public string GetEmployeeRole(string username, string password)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = "SELECT e.role FROM Employee e INNER JOIN [User] u ON e.user_id = u.user_id WHERE u.username = @username AND u.password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        Console.WriteLine("No role found for the employee.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching employee role: " + ex.Message);
                return null; // or throw an exception
            }
        }

        public bool DeleteEmployee(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    // Delete from Employee table
                    string deleteEmployeeQuery = "DELETE FROM Employee WHERE user_id = @UserId";
                    using (SqlCommand deleteEmployeeCmd = new SqlCommand(deleteEmployeeQuery, conn))
                    {
                        deleteEmployeeCmd.Parameters.AddWithValue("@UserId", userId);
                        deleteEmployeeCmd.ExecuteNonQuery();
                    }

                    // Delete from User table
                    string deleteUserQuery = "DELETE FROM [User] WHERE user_id = @UserId";
                    using (SqlCommand deleteUserCmd = new SqlCommand(deleteUserQuery, conn))
                    {
                        deleteUserCmd.Parameters.AddWithValue("@UserId", userId);
                        deleteUserCmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting employee: " + ex.Message);
                return false;
            }
        }

        public bool UpdateEmployeeInfo(string firstName, string lastName, string username, string hashedPassword, string email, string role)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string updateUserInfoQuery = "UPDATE [User] SET first_name = @FirstName, last_name = @LastName, username = @Username, password = @Password, email = @Email WHERE user_id = @UserId";

                    SqlCommand sqlCommand = new SqlCommand(updateUserInfoQuery, conn);
                    sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                    sqlCommand.Parameters.AddWithValue("@Username", username);
                    sqlCommand.Parameters.AddWithValue("@Password", hashedPassword);
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    int affectedRows = sqlCommand.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        string updateEmployeeInfoQuery = "UPDATE Employee SET role = @Role WHERE user_id = @UserId";
                        SqlCommand cmd = new SqlCommand(updateEmployeeInfoQuery, conn);
                        cmd.Parameters.AddWithValue("@Role", role);
                        int roleUpdateRows = cmd.ExecuteNonQuery();

                        if (roleUpdateRows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Failed to update employee role.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows updated in the User table.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating employee info: " + ex.Message);
                return false;
            }
        }

        private bool EmailAlreadyExists(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM [User] WHERE email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking email existence: " + ex.Message);
                return false;
            }
        }
    }
}
