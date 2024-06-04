using NameLibrary;
using System.Collections.Generic;

namespace IRepositories
{
    public interface ICustomerRepo
    {
        bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, int level);
        Customer VerifyCustomerCredentials(string email, string password);
        bool AddWorkoutToFavourites(int customerId, int workoutId);
        int GetCustomerIdByEmail(string email);
        List<Customer> GetAllCustomers();
    }
}
