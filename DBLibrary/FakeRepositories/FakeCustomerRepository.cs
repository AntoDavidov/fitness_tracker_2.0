using System.Collections.Generic;
using System.Linq;
using DBLibrary.IRepositories;
using NameLibrary;

namespace DBLibrary.FakeRepositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;
        private readonly Dictionary<int, List<int>> _customerFavouriteWorkouts;

        public FakeCustomerRepository()
        {
            _customers = new List<Customer>
            {
                new Customer("John", "Smith", "customer1", "password", "customer1@example.com", 70, "BEGINNER"),
                new Customer("Jane", "Smith", "customer2", "password", "customer2@example.com", 65, "INTERMEDIATE")
            };

            _customerFavouriteWorkouts = new Dictionary<int, List<int>>();
        }

        public bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, string level)
        {
            foreach (var customer in _customers)
            {
                if (customer.GetUsername() == username)
                {
                    return false;
                }
            }

            var newCustomer = new Customer(firstName, lastName, username, password, email, weight, level);
            _customers.Add(newCustomer);
            return true;
        }

        public Customer VerifyCustomerCredentials(string email, string password)
        {
            foreach (var customer in _customers)
            {
                if (customer.GetEmail() == email && customer.GetPassword() == password)
                {
                    return customer;
                }
            }
            return null; //Nobody is found
        }

        public bool AddWorkoutToFavourites(int customerId, int workoutId)
        {
            if (!_customerFavouriteWorkouts.ContainsKey(customerId))
            {
                _customerFavouriteWorkouts[customerId] = new List<int>();
            }

            foreach (var id in _customerFavouriteWorkouts[customerId])
            {
                if (id == workoutId)
                {
                    return false; // Workout is already in favourites
                }
            }

            _customerFavouriteWorkouts[customerId].Add(workoutId);
            return true;
        }

        public int GetCustomerIdByEmail(string email)
        {
            foreach (var customer in _customers)
            {
                if (customer.GetEmail() == email)
                {
                    return customer.GetId();
                }
            }
            return -1; 
        }
    }
}
