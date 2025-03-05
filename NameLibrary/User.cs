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
        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        public string GetLastName()
        {
            return lastName;
        }
        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }
        public string GetUsername()
        {
            return username;
        }
        public void SetUsername(string username)
        {
            this.username = username;
        }
        public string GetPassword()
        {
            return password;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public virtual string ToString()
        {
            return $"{id}: {firstName} {lastName};";
        }

    }
}
