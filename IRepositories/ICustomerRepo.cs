using ExerciseLibrary;
using NameLibrary;
using System.Collections.Generic;

namespace IRepositories
{
    public interface ICustomerRepo
    {
        bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, int level, int age);
        Customer VerifyCustomerCredentials(string email, string password);
        bool AddWorkoutToFavourites(int customerId, int workoutId);
        int GetCustomerIdByEmail(string email);
        List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int customerId);
        List<Workouts> GetFavoriteWorkouts(int customerId);
        Dictionary<int, List<int>> GetCustomerFavoriteWorkouts(); 
        List<Workouts> GetWorkoutsByIds(List<int> workoutIds); 
        void MarkExerciseAsCompleted(int customerId, int workoutId, int exerciseId);
        void UnmarkExerciseAsCompleted(int customerId, int workoutId, int exerciseId);
        List<int> GetCompletedExercises(int customerId, int workoutId);
    }
}
