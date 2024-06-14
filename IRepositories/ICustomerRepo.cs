using ExerciseLibrary;
using NameLibrary;
using System.Collections.Generic;

namespace IRepositories
{
    public interface ICustomerRepo
    {
        public bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, Level level, int age);
        Customer VerifyCustomerCredentials(string email, string password);
        bool AddWorkoutToFavourites(int customerId, int workoutId);
        bool RemoveWorkoutFromFavourites(int customerId, int workoutId);
        int GetCustomerIdByEmail(string email);
        List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int customerId);
        List<Workouts> GetFavoriteWorkouts(int customerId);
        List<Workouts> GetFavoriteWorkoutsByPage(int customerId, int pageIndex, int pageSize);
        public int GetTotalFavoriteWorkouts(int customerId);
        Dictionary<int, List<int>> GetAllCustomerFavoriteWorkouts(); 
        List<Workouts> GetWorkoutsByIds(List<int> workoutIds); 
    }
}
