using DBLibrary.IRepositories;
using NameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.FakeDBManager
{
    public class FakeCustomerDBManager : ICustomerRepository
    {
        private Dictionary<int, Customer> customers;
        public FakeCustomerDBManager() 
        {
            this.customers = new Dictionary<int, Customer>();
        }
        public bool AddCustomerToDB(string firstName, string lastName, string username, string password, string email, double weight, string level)
        {
            Customer newCustomer = new Customer(firstName, lastName, username, password, email, weight, level);
            this.customers.Add(newCustomer.GetId(), newCustomer);
            return true;
        }

        public Customer VerifyCustomerCredentials(string email, string password)
        {

        }
        public bool AddWorkoutToFavourites(int customerId, int workoutId)
        {

        }
        public int GetCustomerIdByEmail(string email)
        {

        }
    }
}
