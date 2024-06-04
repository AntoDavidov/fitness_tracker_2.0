using IRepositories;
using NameLibrary;
using System.Collections.Generic;

namespace Unit_Testing.FakeRepo
{
    public class FakeCustomerRepo : ICustomerRepo
    {
        private readonly List<Customer> _customers;
        private readonly Dictionary<int, List<int>> _customerFavouriteWorkouts;

        public FakeCustomerRepo()
        {
            _customers = new List<Customer>
            {
                new Customer(1, "John", "Smith", "1customer1", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "1customer1@example.com", 70, 1),
                new Customer(2, "Jane", "Smith", "2customer2", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "2customer2@example.com", 65, 2)
            };

            _customerFavouriteWorkouts = new Dictionary<int, List<int>>();
        }

        public bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, int level)
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
            return null;
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
                    return false;
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

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }
    }
}
