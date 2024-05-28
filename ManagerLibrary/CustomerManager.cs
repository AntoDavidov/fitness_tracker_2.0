using DBLibrary;
using IRepositories;
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
        private readonly ICustomerRepo _customerRepository;
        private CustomerDBManager customerDBManager;
        private PasswordManager passwordManager;
        public CustomerManager(ICustomerRepo customerRepo)
        {
            customerDBManager = new CustomerDBManager();
            passwordManager = new PasswordManager();
            _customerRepository = customerRepo;
        }
        public Customer VerifyLogin(LoginDTO login)
        {
            string password = passwordManager.HashPassword(login.Password);
            return _customerRepository.VerifyCustomerCredentials(login.Email, password);
        }

        public void AddCustomer(SignupDTO signup)
        {
            string hashedPassword = passwordManager.HashPassword(signup.Password);
            _customerRepository.AddCustomerToDB(signup.FirstName, signup.LastName,signup.UserName, hashedPassword, signup.Email, signup.Weight, signup.Level);
        }
        public int GetCustomerIdByEmail(string email)
        {
            return _customerRepository.GetCustomerIdByEmail(email);
        }
        public bool AddWorkoutToFavourites(int customerId, int workoutId)
        {
            return _customerRepository.AddWorkoutToFavourites(customerId, workoutId);
        }
    }
}
