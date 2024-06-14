using ManagerLibrary.Exceptions;
using NameLibrary;
using IRepositories;
using System.Collections.Generic;
using ExerciseLibrary;

namespace ManagerLibrary
{
    public class CustomerManager
    {
        private readonly ICustomerRepo _customerRepository;
        private PasswordManager passwordManager;

        public CustomerManager(ICustomerRepo customerRepository)
        {
            _customerRepository = customerRepository;
            passwordManager = new PasswordManager();
        }

        public void AddCustomer(string firstName, string lastName, string username, string password, string email, double weight, Level level, int age)
        {
            foreach (var existingCustomer in _customerRepository.GetAllCustomers())
            {
                if (existingCustomer.GetUsername() == username)
                {
                    throw new DuplicateUsernameException();
                }
                if (existingCustomer.GetEmail() == email)
                {
                    throw new DuplicateEmailException();
                }
            }

            string passwordHashed = passwordManager.HashPassword(password);
            _customerRepository.AddCustomerToDB(firstName, lastName, username, passwordHashed, email, weight, level, age);
        }

        public Customer VerifyCustomerCredentials(string email, string password)
        {
            string hashedPassword = passwordManager.HashPassword(password);
            return _customerRepository.VerifyCustomerCredentials(email, hashedPassword);
        }

        public bool AddWorkoutToFavourites(int customerId, int workoutId)
        {
            return _customerRepository.AddWorkoutToFavourites(customerId, workoutId);
        }
        public bool RemoveWorkoutFromFavourites(int customerId, int workoutId)
        {
            return _customerRepository.RemoveWorkoutFromFavourites(customerId, workoutId);
        }


        public int GetCustomerIdByEmail(string email)
        {
            return _customerRepository.GetCustomerIdByEmail(email);
        }
        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
        public List<Workouts> GetFavoriteWorkoutsByPage(int userId, int pageIndex, int pageSize)
        {
            return _customerRepository.GetFavoriteWorkoutsByPage(userId, pageIndex, pageSize);
        }
        public int GetTotalFavoriteWorkoutsCount(int userId)
        {
            return _customerRepository.GetTotalFavoriteWorkouts(userId);
        }


        //public Dictionary<int, List<int>> GetAllCustomerFavoriteWorkouts()
        //{
        //    return _customerRepository.GetAllCustomerFavoriteWorkouts();
        //}
        public List<Workouts> GetFavoriteWorkouts(int customerId)
        {
            return _customerRepository.GetFavoriteWorkouts(customerId);
        }
    }
}
