using DBLibrary;
using DBLibrary.IRepositories;
using NameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class CustomerManager : PasswordManager
    {
        private readonly ICustomerRepository _customerRepository;
        private CustomerDBManager customerDBManager;
        public CustomerManager(ICustomerRepository customerRepo)
        {
            customerDBManager = new CustomerDBManager();
            _customerRepository = customerRepo;
        }
        public Customer VerifyLogin(LoginDTO login)
        {
            string password = HashPassword(login.Password);
            return _customerRepository.VerifyCustomerCredentials(login.Email, password);
        }

        public void AddCustomer(SignupDTO signup)
        {
            string hashedPassword = HashPassword(signup.Password);
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
