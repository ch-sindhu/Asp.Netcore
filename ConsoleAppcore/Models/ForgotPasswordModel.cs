using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ConsoleAppcore.Models
{
    public class ForgotPasswordModel
    {
        [Required,EmailAddress,Display(Name ="Register email address")]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
