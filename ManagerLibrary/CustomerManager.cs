using DBLibrary;
using NameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class CustomerManager
    {
        private CustomerDBManager customerDBManager;
        public CustomerManager()
        {
            customerDBManager = new CustomerDBManager();
        }
        public Customer VerifyLogin(LoginDTO login)
        {
            return customerDBManager.VerifyCustomerCredentials(login.Email, login.Password);
        }

        public void AddCustomer(SignupDTO signup)
        {
            customerDBManager.AddCustomerToDB(signup.FirstName, signup.LastName,signup.UserName, signup.Password, signup.Email, signup.Weight, signup.Level);
        }
        public int GetCustomerIdByEmail(string email)
        {
            return customerDBManager.GetCustomerIdByEmail(email);
        }
        public bool AddWorkoutToFavourites(int customerId, int workoutId)
        {
            return customerDBManager.AddWorkoutToFavorites(customerId, workoutId);
        }
    }
}
