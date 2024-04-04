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
        public User() { }
        public int ID { get; set; }
        [Required, MinLength(3, ErrorMessage = "Minimum 3 characters.")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, MinLength(5, ErrorMessage ="A username can be from 5 - 30 characters.")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }


        public virtual string ToString()
        {
            return $"{ID}: {FirstName} {LastName};";
        }
    }
}
