using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameLibrary.DTOs
{
    public class SignupDTO
    {
        public int ID { get; set; }


        [Required, MinLength(3, ErrorMessage = "Minimum 3 characters")]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }


        [Required, MinLength(5, ErrorMessage = "A username can be from 5 - 30 characters")]
        public string UserName { get; set; }


        [Required]
        public string Password { get; set; }


        [Required, EmailAddress]
        public string Email { get; set; }


        [Required]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Level is required")]
        public Level Level { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
    }
}
