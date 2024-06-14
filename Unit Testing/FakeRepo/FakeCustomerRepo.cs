using ExerciseLibrary;
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
                new Customer(1, "John", "Smith", "1customer1", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "1customer1@example.com", 70, Level.Beginner, 20),
                new Customer(2, "Jane", "Smith", "2customer2", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "2customer2@example.com", 65, Level.Intermediate, 23)
            };

            _customerFavouriteWorkouts = new Dictionary<int, List<int>>
            {
                { 1, new List<int> { 1, 2, 3 } },
                { 2, new List<int> { 1, 5, 6 } }
            };

        }

        public bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, Level level, int age)
        {
            foreach (var customer in _customers)
            {
                if (customer.GetUsername() == username)
                {
                    return false;
                }
            }

            var newCustomer = new Customer(firstName, lastName, username, password, email, weight, level, age);
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

        public List<Workouts> GetFavoriteWorkoutsByPage(int customerId, int pageIndex, int pageSize)
        {
            var favoriteWorkoutIds = new List<int>();
            if (_customerFavouriteWorkouts.ContainsKey(customerId))
            {
                favoriteWorkoutIds = _customerFavouriteWorkouts[customerId];
            }

            var paginatedWorkoutIds = new List<int>();
            int startIndex = (pageIndex - 1) * pageSize;
            for (int i = startIndex; i < startIndex + pageSize && i < favoriteWorkoutIds.Count; i++)
            {
                paginatedWorkoutIds.Add(favoriteWorkoutIds[i]);
            }

            return GetWorkoutsByIds(paginatedWorkoutIds);
        }

        public bool RemoveWorkoutFromFavourites(int customerId, int workoutId)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
            {
                return false;
            }

            var favoriteWorkoutIds = new List<int>();
            if (_customerFavouriteWorkouts.ContainsKey(customerId))
            {
                favoriteWorkoutIds = _customerFavouriteWorkouts[customerId];
            }

            if (favoriteWorkoutIds == null)
            {
                return false;
            }

            for (int i = 0; i < favoriteWorkoutIds.Count; i++)
            {
                if (favoriteWorkoutIds[i] == workoutId)
                {
                    favoriteWorkoutIds.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public int GetTotalFavoriteWorkouts(int customerId)
        {
            if (_customerFavouriteWorkouts.ContainsKey(customerId))
            {
                return _customerFavouriteWorkouts[customerId].Count;
            }
            return 0;
        }

        public bool AddWorkoutToFavourites(int customerId, int workoutId)
        {
            if (!_customerFavouriteWorkouts.ContainsKey(customerId))
            {
                _customerFavouriteWorkouts[customerId] = new List<int>();
            }

            var favoriteWorkoutIds = _customerFavouriteWorkouts[customerId];
            foreach (var id in favoriteWorkoutIds)
            {
                if (id == workoutId)
                {
                    return false;
                }
            }

            favoriteWorkoutIds.Add(workoutId);
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

        public Customer GetCustomerById(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.GetId() == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public List<Workouts> GetFavoriteWorkouts(int customerId)
        {
            var favoriteWorkouts = new List<Workouts>();

            if (_customerFavouriteWorkouts.ContainsKey(customerId))
            {
                foreach (var workoutId in _customerFavouriteWorkouts[customerId])
                {
                    var workout = GetWorkoutById(workoutId);
                    if (workout != null)
                    {
                        favoriteWorkouts.Add(workout);
                    }
                }
            }

            return favoriteWorkouts;
        }

        private Workouts GetWorkoutById(int workoutId)
        {
            // Simulate fetching a workout by ID
            return new Workouts(workoutId, $"Workout {workoutId}", $"Description for workout {workoutId}", Level.Intermediate);
        }


        public Dictionary<int, List<int>> GetAllCustomerFavoriteWorkouts()
        {
            return _customerFavouriteWorkouts;
        }

        public List<Workouts> GetWorkoutsByIds(List<int> workoutIds)
        {
            var workouts = new List<Workouts>
            {
                new Workouts(1, "Workout 1", "Description 1", Level.Beginner),
                new Workouts(2, "Workout 2", "Description 2", Level.Advanced),
                new Workouts(3, "Workout 3", "Description 3", Level.Intermediate),
                new Workouts(5, "Workout 5", "Description 5", Level.Advanced),
                new Workouts(6, "Workout 6", "Description 6", Level.Beginner)
            };

            var result = new List<Workouts>();
            foreach (var id in workoutIds)
            {
                foreach (var workout in workouts)
                {
                    if (workout.GetId() == id)
                    {
                        result.Add(workout);
                    }
                }
            }

            return result;
        }
    }
}
