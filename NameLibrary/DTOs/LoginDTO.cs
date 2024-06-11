using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameLibrary.DTOs
{
    public class LoginDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
