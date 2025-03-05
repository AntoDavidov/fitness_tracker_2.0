using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameLibrary
{
    public class Customer : User
    {
        private double userWeight;
        private Level userLevel; // Changed from int to Level enum
        private int age;

        public Customer(string firstName, string lastName, string username, string password, string email, double weight, Level level, int age) : base(firstName, lastName, username, password, email)
        {
            this.userWeight = weight;
            this.userLevel = level;
            this.age = age;
        }

        public Customer(int id, string firstName, string lastName, string username, string password, string email, double weight, Level level) : base(id, firstName, lastName, username, password, email)
        {
            this.userWeight = weight;
            this.userLevel = level;
        }
        public Customer(int id, string firstName, string lastName, string username, string password, string email, double weight, Level level, int age) : base(id, firstName, lastName, username, password, email)
        {
            this.userWeight = weight;
            this.userLevel = level;
            this.age = age;
        }

        public Customer() { }

        public double GetWeight() { return userWeight; }

        public Level GetLevel() { return userLevel; } // Changed return type to Level
        public int GetAge() { return age; }

        public override string ToString()
        {
            return base.ToString() + $"Your level: {userLevel}";
        }
    }
}
