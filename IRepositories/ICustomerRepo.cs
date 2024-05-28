using NameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface ICustomerRepo
    {
        bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, string level);
        Customer VerifyCustomerCredentials(string email, string password);
        bool AddWorkoutToFavourites(int customerId, int workoutId);
        int GetCustomerIdByEmail(string email);
    }
}
