using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameLibrary
{
    public class User
    {
        private int id;
        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private string email;

        public User(int id, string firstName, string lastName, string username, string password, string email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public User(string firstName, string lastName, string username, string password, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.email = email;
        }
        public User(int id, string firstName, string lastName, string username, string email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.email = email;
        }

        public User()
        {
        }

        public int GetId()
        {
            return id;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetEmail()
        {
            return email;
        }

        public virtual string ToString()
        {
            return $"{id}: {firstName} {lastName};";
        }
    }
}

