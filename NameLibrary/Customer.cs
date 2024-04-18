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
        private float userWeight;
        private Level userLevel;

        public Customer(string firstName, string lastName, string username, string password, string email, float weight, string level) : base(firstName, lastName, username, password, email)
        {
            this.userWeight = weight;
            this.userLevel = ParseLevel(level);
        }

        public Customer(int id, string firstName, string lastName, string username, string password, string email, float weight, string level) : base(id, firstName, lastName, username, password, email)
        {
            this.userWeight = weight;
            this.userLevel = ParseLevel(level);
        }

        public Customer() { }

        public float GetWeight() { return userWeight; }

        public Level GetLevel() { return userLevel; }

        private Level ParseLevel(string level)
        {
            if (Enum.TryParse<Level>(level, out Level parsedLevel))
            {
                return parsedLevel;
            }
            else
            {
                // Handle invalid level
                throw new ArgumentException("Invalid level value.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Your level: {userLevel}";
        }
    }

}
