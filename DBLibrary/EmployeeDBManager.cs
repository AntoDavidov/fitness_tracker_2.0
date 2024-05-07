using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NameLibrary;
using System.Security.Cryptography;

namespace DBLibrary
{
    public class EmployeeDBManager : DBDal
    {
        public EmployeeDBManager()
        {
        }
        public bool AddEmployeeToDB(Employee employee)
        {
            try
            {
                if (EmailAlreadyExists(employee.GetEmail()))
                {
                    throw new Exception();
                }
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string hashedPassword = HashPassword(employee.GetPassword());


                    // Insert into User table
                    string insertUserQuery = "INSERT INTO [User] (first_name, last_name, username, [password], email) VALUES (@FirstName, @LastName, @Username, @Password, @Email); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, conn);
                    insertUserCommand.Parameters.AddWithValue("@FirstName", employee.GetFirstName());
                    insertUserCommand.Parameters.AddWithValue("@LastName", employee.GetLastName());
                    insertUserCommand.Parameters.AddWithValue("@Username", employee.GetUsername());
                    insertUserCommand.Parameters.AddWithValue("@Password", hashedPassword); // Use hashed password
                    insertUserCommand.Parameters.AddWithValue("@Email", employee.GetEmail());
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

        public bool EmailAlreadyExists(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM [User] WHERE email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking if email exists: " + ex.Message);
                return false;
            }
        }


        public List<Employee> GetAllEmployeesFromDB()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT e.id, u.first_name, u.last_name, u.username, u.password, u.email, e.role
                FROM Employee e
                INNER JOIN [User] u ON e.user_id = u.id";

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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT e.id, u.first_name, u.last_name, u.username, u.password, u.email, e.role " +
                                   "FROM Employee e INNER JOIN [User] u ON e.user_id = u.id " +
                                   "WHERE u.username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
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

        
        public bool VerifyEmployeeCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT password FROM [User] WHERE username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    // Retrieve the hashed password from the database
                    string hashedPassword = cmd.ExecuteScalar()?.ToString();

                    // If no password was found for the username, return false
                    if (string.IsNullOrEmpty(hashedPassword))
                        return false;
                    bool verified = VerifyPassword(password, hashedPassword);
                    return verified;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verifying employee credentials: " + ex.Message);
                return false;
            }
        }
        public string GetEmployeeRole(string username, string password)
        {
            try
            {
                string hashedPassword = HashPassword(password);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT e.role FROM Employee e INNER JOIN [User] u ON e.user_id = u.id WHERE u.username = @username AND u.password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

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
        public bool UpdateEmployeeInfo(Employee employee)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string hashedPassword = HashPassword(employee.GetPassword());
                    string updateUserInfoQuery = "UPDATE [User] SET first_name = @FirstName, last_name = @LastName, username = @Username, password = @Password, email = @Email WHERE id = @UserId";

                    SqlCommand sqlCommand = new SqlCommand(updateUserInfoQuery, conn);
                    sqlCommand.Parameters.AddWithValue("@FirstName", employee.GetFirstName());
                    sqlCommand.Parameters.AddWithValue("@LastName", employee.GetLastName());
                    sqlCommand.Parameters.AddWithValue("@Username", employee.GetUsername());
                    sqlCommand.Parameters.AddWithValue("@Password", hashedPassword);
                    sqlCommand.Parameters.AddWithValue("@Email", employee.GetEmail());
                    sqlCommand.Parameters.AddWithValue("@UserId", employee.GetId()); // Assuming GetId() method returns the user id
                    int affectedRows = sqlCommand.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        string updateEmployeeInfoQuery = "UPDATE Employee SET role = @Role WHERE user_id = @UserId";
                        SqlCommand cmd = new SqlCommand(updateEmployeeInfoQuery, conn);
                        cmd.Parameters.AddWithValue("@Role", employee.Role());
                        cmd.Parameters.AddWithValue("@UserId", employee.GetId()); // Assuming GetId() method returns the user id
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
                        return false; // No rows updated in the User table
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating employee info: " + ex.Message);
                return false;
            }
        }
    }
}
