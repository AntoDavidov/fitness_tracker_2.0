using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public class DBDal
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi530206_fitnestrak;User Id=dbi530206_fitnestrak;Password=1234;";

        // Method to verify a password against a hashed password
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return password.Equals(hashedPassword);
        }

        //public bool EmailAlreadyExists(string email)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            string query = "SELECT COUNT(*) FROM [User] WHERE email = @Email";
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@Email", email);

        //            int count = Convert.ToInt32(cmd.ExecuteScalar());
        //            return count > 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error checking if email exists: " + ex.Message);
        //        return false;
        //    }
            
        //}
        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
