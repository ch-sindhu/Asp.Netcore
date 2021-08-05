using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ConsoleAppcore.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string UserId { set; get; }
        [Required]
        public string Token { set; get; }
        [Required,DataType(DataType.Password)]
        public string NewPassword { set; get; }

        [Required,DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { set; get;}
        public bool IsSuccess { set; get; }

    }
}
