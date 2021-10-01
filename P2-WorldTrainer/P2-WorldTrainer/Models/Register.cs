using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P2_WorldTrainer.Models
{
    public class Register
    {

        [Required]
        [DisplayName("First Name")]

        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]

        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "**Email must be properly formatted.")]
        public string Email { get; set; }
        [Required]


        public string Role { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
