using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameLibrary
{
    public class Employee : User
    { 
        private string role;

        public Employee(int id, string firstName, string lastName, string username, string password, string email, string role) : base(id, firstName, lastName, username, password, email)
        {
            this.role = role;
        }
        public Employee(string firstName, string lastName, string username, string password, string email, string role) : base(firstName, lastName, username, password, email)
        {
            this.role = role;
        }
        public string Role() { return role; } 
        public void SetRole(string role) { this.role = role; }
        public override string ToString()   
        {
            return base.ToString() + " Role: " + role;
        }
    }
}
