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

        public void AddCustomer(string firstName, string lastName, string username, string password, string email, double weight, int level)
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
            _customerRepository.AddCustomerToDB(firstName, lastName, username, passwordHashed, email, weight, level);
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

        public int GetCustomerIdByEmail(string email)
        {
            return _customerRepository.GetCustomerIdByEmail(email);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
        public Dictionary<int, List<int>> GetCustomerFavoriteWorkouts()
        {
            return _customerRepository.GetCustomerFavoriteWorkouts();
        }
        public List<Workouts> GetFavoriteWorkouts(int customerId)
        {
            return _customerRepository.GetFavoriteWorkouts(customerId);
        }
        public void MarkExerciseAsCompleted(int customerId, int workoutId, int exerciseId)
        {
            _customerRepository.MarkExerciseAsCompleted(customerId, workoutId, exerciseId);
        }

        public void UnmarkExerciseAsCompleted(int customerId, int workoutId, int exerciseId)
        {
            _customerRepository.UnmarkExerciseAsCompleted(customerId, workoutId, exerciseId);
        }

        public List<int> GetCompletedExercises(int customerId, int workoutId)
        {
            return _customerRepository.GetCompletedExercises(customerId, workoutId);
        }

    }
}
