using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppcore.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your FirstName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage ="Please enter your Email")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="please enter a valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a strong password")]
        [Display(Name = "Password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password doesn't match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
